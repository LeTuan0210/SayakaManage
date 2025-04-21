using Aspose.Cells;
using AutoMapper;
using Azure.Core;
using DataModels.Entities;
using DataServices.Interfaces;
using DataViewModels.Requests.MemberInfo;
using DataViewModels.Responses.MemberInfo;
using Extensions;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using System.Globalization;
using System.Net.Http.Json;

namespace BusinessServices.Extensions
{
    public class SeedData(IWebHostEnvironment env, IRestaurantDataServices _restaurantService, IMenuDataServices _menuService, ISystemPromotionDataServices _promotionService, IMemberDataServices _memberService, IMapper _mapper)
    {
        public async Task<List<RestaurantInfo>> SeedRestaurants(IBrowserFile file)
        {
            try
            {
                var catePath = Path.Combine(env.WebRootPath, "uploads");

                if (!Directory.Exists(catePath))
                    Directory.CreateDirectory(catePath);

                await using FileStream fileStream = new(Path.Combine(catePath, file.Name), FileMode.Create);

                await file.OpenReadStream(file.Size).CopyToAsync(fileStream);

                Workbook workbook = new Workbook(fileStream);

                Worksheet worksheet = workbook.Worksheets["restaurant"];

                List<RestaurantInfo> restaurants = new List<RestaurantInfo>();

                int maxRow = worksheet.Cells.MaxDataRow;

                if (maxRow <= 0)
                    return null;

                Cells data = worksheet.Cells;

                for (int i = 2; i <= maxRow + 1; i++)
                {
                    RestaurantInfo resraurant = new RestaurantInfo();
                    try
                    {
                        resraurant.Id = Guid.NewGuid();
                        resraurant.restaurantName = data[$"A{i}"].Value.ToString();
                        resraurant.restaurantArea = data[$"C{i}"].Value.ToString();
                        resraurant.restaurantAddress = data[$"D{i}"].Value.ToString();
                        resraurant.restaurantPhone = "0" + data[$"E{i}"].Value.ToString();
                        resraurant.restaurantAliasName = resraurant.restaurantName.ToAliasString();
                    }
                    catch (Exception ex)
                    {
                        resraurant = new RestaurantInfo();
                    }
                    restaurants.Add(resraurant);
                }

                var result = await _restaurantService.CreateListRestaurants(restaurants);

                if (result == null)
                    return null;

                return restaurants;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<List<RestaurantMenu>> SeedMenu(IBrowserFile file)
        {
            try
            {
                var catePath = Path.Combine(env.WebRootPath, "uploads");

                if (!Directory.Exists(catePath))
                    Directory.CreateDirectory(catePath);

                await using FileStream fileStream = new(Path.Combine(catePath, file.Name), FileMode.Create);

                await file.OpenReadStream(file.Size).CopyToAsync(fileStream);

                Workbook workbook = new Workbook(fileStream);

                Worksheet worksheet = workbook.Worksheets["menu"];

                List<RestaurantMenu> menus = new List<RestaurantMenu>();

                int maxRow = worksheet.Cells.MaxDataRow;

                if (maxRow <= 0)
                    return null;

                Cells data = worksheet.Cells;

                for (int i = 2; i <= maxRow + 1; i++)
                {
                    RestaurantMenu menu = new RestaurantMenu();
                    try
                    {
                        menu.Id = Guid.NewGuid();
                        menu.menuName = data[$"A{i}"].Value.ToString();
                        menu.menuPrice = Convert.ToInt32(data[$"C{i}"].Value.ToString());
                        menu.menuType = data[$"D{i}"].Value.ToString();
                        menu.menuAliasName = menu.menuName.ToAliasString();
                    }
                    catch (Exception ex)
                    {
                        menu = new RestaurantMenu();
                    }
                    menus.Add(menu);
                }

                var result = await _menuService.CreateListMenuAsync(menus);

                if (result == null)
                    return null;

                return menus;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<List<SystemPromotion>> SeedPromotion(IBrowserFile file)
        {
            try
            {
                var catePath = Path.Combine(env.WebRootPath, "uploads");

                if (!Directory.Exists(catePath))
                    Directory.CreateDirectory(catePath);

                await using FileStream fileStream = new(Path.Combine(catePath, file.Name), FileMode.Create);

                await file.OpenReadStream(file.Size).CopyToAsync(fileStream);

                Workbook workbook = new Workbook(fileStream);

                Worksheet worksheet = workbook.Worksheets["promotion"];

                List<SystemPromotion> promotions = new List<SystemPromotion>();

                int maxRow = worksheet.Cells.MaxDataRow;

                if (maxRow <= 0)
                    return null;

                Cells data = worksheet.Cells;

                for (int i = 2; i <= maxRow + 1; i++)
                {
                    SystemPromotion promotion = new SystemPromotion();
                    try
                    {
                        promotion.Id = Guid.NewGuid();
                        promotion.promotionName = data[$"A{i}"].Value.ToString();
                        promotion.promotionAlias = promotion.promotionName.ToAliasString();
                    }
                    catch (Exception ex)
                    {
                        promotion = new SystemPromotion();
                    }
                    promotions.Add(promotion);
                }

                var result = await _promotionService.CreateListPromotion(promotions);

                if (result == null)
                    return null;

                return promotions;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task SeedMember()
        {
            using (var httpclient = new HttpClient())
            {
                var listMember = await httpclient.GetFromJsonAsync<List<SayakaMember>>("https://sayaka.vn/api/zalo/getmember");

                var listSystemMember = await _memberService.GetAllMemberAsync(new DataModels.Filter.MemberFilter());

                foreach(var item in listSystemMember)
                {
                    try
                    {
                        var member = listMember.FirstOrDefault(x => x.id == item.user_Id);

                        if (member != null)
                        {
                            item.memberPhone = member.phone;
                        }

                        if (item.memberPhone.StartsWith("84") && item.memberPhone.Length == 11)
                        {
                            item.memberPhone = "0" + item.memberPhone.Substring(2);
                        }

                        await _memberService.UpdateMemberAsync(item);
                    }
                    catch
                    {

                    }
                }
            }
            //for (int i = 0; i < 6200; i += 50)
            //{
            //    string accesstoken = "MLryB-Gpx3PPNdqdwJNeFb5UVItkAEzWAZW72i1PaqjzH0CSaL_WIY1z4GlOREzRE68P2jjf_M8gO0mQr7RaTYHfV3pVM-bxD5f_AlfMf4T3NM1KXMgB16S2PcZP48PuAXng89ChXcjTAHKvhYZLKMCf6W6-6FrLJpaO1geDxrSIDmOSxHNrLLq5PX6n9Py7Vr18QiTkf2GROaynt4sjMYzINpN7NQr-ArHTQ9DTdYbLN5CykZocKNuXG2Qc3x8tMJ8YHULSnWC1JZ9wwLdV3LHi7MALGkmLVK8AR9TjyYWlQXivuLt-IWHaEWxz2gjwE3HOFVabmImI9IvKoZhX40iG45xd98WL5Z5k1CWScHGiBLDCyGMXNnvlJKxxNO4cHZnaPuiXYoLZ6crKk7E6BGDjP4PBYLYX8EGhx3y";

            //    using (var httpclient = new HttpClient())
            //    {
            //        httpclient.DefaultRequestHeaders.Add("access_token", accesstoken);

            //        string GetListUserEndpoint = $"https://openapi.zalo.me/v3.0/oa/user/getlist?data={{\"offset\":{i},\"count\":50,\"is_follower\":\"true\"}}";

            //        var listUser = await httpclient.GetFromJsonAsync<ZaloListUser>(GetListUserEndpoint);

            //        foreach (var item in listUser.data.users)
            //        {
            //            try
            //            {
            //                string GetUserDataEndpoint = $"https://openapi.zalo.me/v3.0/oa/user/detail?data={{\"user_id\":\"{item.user_id}\"}}";

            //                var zaloMember = await httpclient.GetFromJsonAsync<ZaloOAUserDetailModel>(GetUserDataEndpoint);

            //                var systemMember = await _memberService.GetMemberAsync(zaloMember.data.user_id_by_app);

            //                if (systemMember == null)
            //                {
            //                    var createUserModel = new CreateMemberModel
            //                    {
            //                        user_Id = zaloMember.data.user_id,
            //                        user_Id_By_App = zaloMember.data.user_id_by_app,
            //                        memberName = zaloMember.data.display_name,
            //                        isActive = zaloMember.data.user_is_follower,
            //                        memberAvatar = zaloMember.data.avatar,
            //                        memberPhone = zaloMember.data.shared_info.phone.ToString()
            //                    };

            //                    if (DateTime.TryParseExact(zaloMember.data.shared_info.user_dob, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime cusBirthday))
            //                    {
            //                        createUserModel.memberBirthday = cusBirthday;
            //                    }

            //                    var newMember = await _memberService.CreateNewMemberAsync(_mapper.Map<MemberInfo>(createUserModel));
            //                }
            //                else
            //                {
            //                    if (DateTime.TryParseExact(zaloMember.data.shared_info.user_dob, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime cusBirthday))
            //                    {
            //                        systemMember.memberBirthday = cusBirthday;
            //                    }
            //                    systemMember.memberAvatar = zaloMember.data.avatar;
            //                    systemMember.memberPhone = string.IsNullOrEmpty(systemMember.memberPhone) ? systemMember.memberPhone : zaloMember.data.shared_info.phone.ToString();
            //                    var updateUser = await _memberService.UpdateMemberAsync(systemMember);
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                Console.WriteLine(ex.Message);
            //            }
            //        }

            //    }
            //}
        }
        public async Task<List<ZaloToken>> SeedZaloToken()
        {
            return new List<ZaloToken> { new ZaloToken() };
        }
    }
    public class Data
    {
        public int total { get; set; }
        public int count { get; set; }
        public int offset { get; set; }
        public List<User> users { get; set; }
    }

    public class ZaloListUser
    {
        public Data data { get; set; }
        public int error { get; set; }
        public string message { get; set; }
    }

    public class User
    {
        public string user_id { get; set; }
    }
    public class SayakaMember
    {
        public string id { get; set; }
        public string birthday { get; set; }
        public string phone { get; set; }
    }
}
