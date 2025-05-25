using AutoMapper;
using BusinessServices.Repositories.MemberServices;
using DataModels.Entities;
using DataServices.Interfaces;
using DataViewModels.Requests;
using DataViewModels.Responses;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace BusinessServices.Repositories
{
    public class MemberClientServices : MemberBaseServices, IMemberClientServices
    {
        private readonly IWebHostEnvironment _env;

        private readonly IConfiguration _configuration;

        private readonly IMemberDataServices _memberDataServices;

        private readonly IMapper _mapper;

        private readonly IZaloTokenDataServices _tokenDataServices;

        ProtectedLocalStorage _storage;
        MemberResponseModel? _memberInfo { get; set; }
        public MemberClientServices(IWebHostEnvironment env,
                                    IConfiguration configuration,
                                    ProtectedLocalStorage storage,
                                    IMemberDataServices memberDataServices,
                                    IMapper mapper,
                                    IZaloTokenDataServices tokenDataServices) : base (memberDataServices, mapper)
        {
            _env = env;
            _configuration = configuration;
            _storage = storage;
            _memberDataServices = memberDataServices;
            _mapper = mapper;
            _tokenDataServices = tokenDataServices;
        }
        //Authorize User

        #region
        // Get User AccessToken
        private async Task<MemberAccessTokenModel> GetUserAccessToken(string authorizeCode)
        {
            using (var client = new HttpClient())
            {
                string GetUserAccessTokenUri = _configuration["ZaloManager:ZaloAuthUri"];

                client.DefaultRequestHeaders.Add("secret_key", _configuration["ZaloManager:Client_Secret"]);

                var data = new Dictionary<string, string>
                    {
                        { "code", authorizeCode },
                        { "app_id", _configuration["ZaloManager:AppId"] },
                        { "grant_type", "authorization_code" }
                    };

                var content = new FormUrlEncodedContent(data);

                var response = await client.PostAsync(GetUserAccessTokenUri, content);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Post To Get Access Token Fail");
                }

                string token = await response.Content.ReadAsStringAsync();

                var token_Result = await response.Content.ReadFromJsonAsync<MemberAccessTokenModel>();

                return token_Result;
            }
        }

        // From Access Token, Get Member Infomation By Zalo App
        private async Task<MemberAppInfo> GetMemberInfomation(string accessToken)
        {
            using (var client = new HttpClient())
            {
                string GetUserInfoUri = _configuration["ZaloManager:GetUserInfoUri"];

                client.DefaultRequestHeaders.Add("access_token", accessToken);

                var userInfo = await client.GetFromJsonAsync<MemberAppInfo>(GetUserInfoUri);

                return userInfo;
            }
        }
        public async Task AuthenticationMember(string authorizeCode = "")
        {
            try
            {
                //var result = await _storage.GetAsync<MemberResponseModel>("user_member");

                MemberInfo? member;

                //if (result.Success)
                //{
                //    _memberInfo = result.Value;

                //    member = await _memberDataServices.GetMemberAsync(_memberInfo.user_Id_By_App);
                //}
                //else
                //{
                //    var token_Result = await GetUserAccessToken(authorizeCode);

                //    var userInfo = await GetMemberInfomation(token_Result.access_token);

                //    member = await _memberDataServices.GetMemberAsync(userInfo.id);
                //}

                var token_Result = await GetUserAccessToken(authorizeCode);

                var userInfo = await GetMemberInfomation(token_Result.access_token);

                member = await _memberDataServices.GetMemberAsync(userInfo.id);

                if (member == null)
                {                    
                    return;
                }

                _memberInfo = _mapper.Map<MemberResponseModel>(member);

                //await _storage.SetAsync("user_member", _memberInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion

        public bool IsAuthenticated()
        {
            return _memberInfo != null ? true : false;
        }        

        public async Task<UpdateMemberModel> GetUpdateMemberModel()
        {
            try
            {
                await AuthenticationMember();

                if (_memberInfo == null || string.IsNullOrEmpty(_memberInfo.user_Id_By_App))
                    return null;

                var result = await _memberDataServices.GetMemberAsync(_memberInfo.user_Id_By_App);

                if(result != null)
                {
                    return _mapper.Map<UpdateMemberModel>(result);
                }    

                return null;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Task<MemberResponseModel> ChangeFavouriteRestaurant(Guid restaurantId, bool status)
        {
            throw new NotImplementedException();
        }

        public async Task<MemberResponseModel> UpdateMemberInfoByUser(UpdateMemberModel model)
        {
            try
            {
                var updateMember = await _memberDataServices.GetMemberAsync(_memberInfo.user_Id_By_App);

                _mapper.Map(model, updateMember);

                updateMember.hasModify = true;

                updateMember = await _memberDataServices.UpdateMemberAsync(updateMember);

                if (updateMember != null)
                {
                    _memberInfo = _mapper.Map<MemberResponseModel>(updateMember);

                    return _memberInfo;
                }                

                return null;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<MemberResponseModel> GetMemberInfo()
        {
            //await AuthenticationMember();

            return _memberInfo ?? null;
        }

        public Task<DataModels.Entities.MemberInfo> GetMemberById(string id)
        {
            throw new NotImplementedException();
        }

        public string IsCompleteInfomation()
        {
            if(_memberInfo == null)
                return "Không xác thực được người dùng";

            string validateResult = "";

            if(string.IsNullOrEmpty(_memberInfo.memberPhone) || _memberInfo.memberPhone.Length > 12 || _memberInfo.memberPhone.Length < 9)
            {
                validateResult += "Số Điện Thoại";
            }

            if(_memberInfo.memberBirthday.Year == DateTime.Now.Year)
            {
                validateResult += ", Sinh Nhật";
            }    

            if(validateResult.StartsWith(", "))
            {
                return validateResult.Substring(2);
            }    

            return validateResult;
        }
    }
}
