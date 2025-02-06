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
        public async Task<List<MemberSayaka>> SeedMember()
        {
            List<MemberSayaka> members;
            using (var httpclient = new HttpClient())
            {
                members = await httpclient.GetFromJsonAsync<List<MemberSayaka>>("https://sayaka.vn/api/zalo/getmember");
            }

            foreach (var item in members)
            {
                var memberInfo = await _memberService.GetMemberAsync(item.id);

                if (memberInfo != null)
                {
                    if(DateTime.TryParseExact(item.birthday, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime cusBirthday))
                    {
                        memberInfo.memberBirthday = cusBirthday;
                        await _memberService.UpdateMemberAsync(memberInfo);
                    }    

                }    
                
                //string accesstoken = "MLryB-Gpx3PPNdqdwJNeFb5UVItkAEzWAZW72i1PaqjzH0CSaL_WIY1z4GlOREzRE68P2jjf_M8gO0mQr7RaTYHfV3pVM-bxD5f_AlfMf4T3NM1KXMgB16S2PcZP48PuAXng89ChXcjTAHKvhYZLKMCf6W6-6FrLJpaO1geDxrSIDmOSxHNrLLq5PX6n9Py7Vr18QiTkf2GROaynt4sjMYzINpN7NQr-ArHTQ9DTdYbLN5CykZocKNuXG2Qc3x8tMJ8YHULSnWC1JZ9wwLdV3LHi7MALGkmLVK8AR9TjyYWlQXivuLt-IWHaEWxz2gjwE3HOFVabmImI9IvKoZhX40iG45xd98WL5Z5k1CWScHGiBLDCyGMXNnvlJKxxNO4cHZnaPuiXYoLZ6crKk7E6BGDjP4PBYLYX8EGhx3y";
                
                //using (var httpclient = new HttpClient())
                //{
                //    httpclient.DefaultRequestHeaders.Add("access_token", accesstoken);

                //    string Endpoint = $"https://openapi.zalo.me/v3.0/oa/user/detail?data={{\"user_id\":\"{item.id}\"}}";

                //    var response = await httpclient.GetAsync(Endpoint);

                //    if(response.IsSuccessStatusCode)
                //    {
                //        var followInfo = await response.Content.ReadFromJsonAsync<ZaloOAUserDetailModel>();

                //        if (followInfo.error == 0)
                //        {
                //            var createUserModel = new CreateMemberModel
                //            {
                //                user_Id = followInfo.data.user_id,
                //                user_Id_By_App = followInfo.data.user_id_by_app,
                //                memberName = followInfo.data.display_name,
                //                isActive = followInfo.data.user_is_follower,
                //            };

                //            var newMember = await _memberService.CreateNewMemberAsync(_mapper.Map<MemberInfo>(createUserModel));

                //            if (newMember == null)
                //                Console.WriteLine(item.id);

                //            var rateLimitRemainValues = response.Headers.GetValues("X-RateLimit-Remain");

                //            if (response.Headers.Contains("X-RateLimit-Remain"))
                //            {
                //                foreach (var value in rateLimitRemainValues)
                //                {
                //                    if (int.TryParse(value, out int rateLimitRemain))
                //                    {
                //                        Console.WriteLine($"X-RateLimit-Remain: {rateLimitRemain}");
                //                        if (rateLimitRemain <= 10)
                //                            await Task.Delay(60000);
                //                    }
                //                    else
                //                    {
                //                        Console.WriteLine($"Không thể chuyển đổi giá trị '{value}' sang số nguyên.");
                //                    }
                //                }
                //            }
                //        }

                //    }
                //    else
                //    {
                //        Console.WriteLine(item.id);
                //    }
                    
                 
            }

            return members;

        }
        public async Task<List<ZaloToken>> SeedZaloToken()
        {
            return new List<ZaloToken> { new ZaloToken() };
        }
    }
    public class MemberSayaka
    {
        public string id { get; set; }
        public string birthday { get; set; }
        public string phone { get; set; }
    }
}
