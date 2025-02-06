using AutoMapper;
using DataServices.Interfaces;
using DataViewModels.Requests;
using DataViewModels.Responses;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace BusinessServices.Repositories
{
    public class MemberClientServices : IMemberClientServices
    {
        private readonly IWebHostEnvironment _env;

        private readonly IConfiguration _configuration;

        private readonly IMemberDataServices _memberDataServices;

        private readonly IMapper _mapper;

        ProtectedLocalStorage _storage;
        MemberResponseModel? _memberInfo { get; set; }
        public MemberClientServices(IWebHostEnvironment env, IConfiguration configuration, ProtectedLocalStorage storage, IMemberDataServices memberDataServices, IMapper mapper)
        {
            _env = env;
            _configuration = configuration;
            _storage = storage;
            _memberDataServices = memberDataServices;
            _mapper = mapper;
        }
        //Authorize User

        #region
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
                var result = await _storage.GetAsync<MemberResponseModel>("user_member");

                if (result.Success)
                {
                    _memberInfo = result.Value;
                    return;
                }

                var token_Result = await GetUserAccessToken(authorizeCode);

                var userInfo = await GetMemberInfomation(token_Result.access_token);

                var member = await _memberDataServices.GetMemberAsync(userInfo.id);

                if (member == null)
                    return;

                _memberInfo = _mapper.Map<MemberResponseModel>(member);

                await _storage.SetAsync("user_member", _memberInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion

        public bool IsAuthenticate()
        {
            return _memberInfo != null ? true : false;
        }        

        public Task<UpdateMemberModel> GetUpdateMemberModel()
        {
            throw new NotImplementedException();
        }

        public Task<MemberResponseModel> ChangeFavouriteRestaurant(Guid restaurantId, bool status)
        {
            throw new NotImplementedException();
        }

        public Task<MemberResponseModel> UpdateMemberInfoByUser(UpdateMemberModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<MemberResponseModel> GetMemberInfo()
        {
            await AuthenticationMember();

            return _memberInfo ?? null;
        }

        public Task<DataModels.Entities.MemberInfo> GetMemberById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
