using DataModels.Entities;
using DataServices.Interfaces;
using DataViewModels.Requests;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace BusinessServices.Repositories
{
    public class ZaloTokenServices(IZaloTokenDataServices _tokenService, IConfiguration _config) : IZaloTokenServices
    {
        ZaloToken? access_token;
        public async Task<string> GetAccessToken()
        {
            try
            {
                if(access_token != null && DateTime.Now < access_token.expireTime)
                    return access_token.tokenValue;

                access_token = await _tokenService.GetTokenById("access_token");

                if(string.IsNullOrEmpty(access_token.tokenValue))
                    return string.Empty;

                if(DateTime.Now < access_token.expireTime)
                    return access_token.tokenValue;

                access_token = await UpdateToken();

                if (access_token == null)
                    return string.Empty;

                return access_token.tokenValue;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                return string.Empty;
            }
        }

        async Task<ZaloToken> UpdateToken()
        {
            var refresh_token = await _tokenService.GetTokenById("refresh_token");

            if (string.IsNullOrEmpty(refresh_token.tokenValue))
            {
                Console.WriteLine("Null RefreshToken");
                return null;
            }

            using (var httpClient = new HttpClient())
            {
                string Endpoint = _config["ZaloManager:OA_Access_Token"];

                httpClient.DefaultRequestHeaders.Add("secret_key", _config["ZaloManager:Client_Secret"]);

                var data = new Dictionary<string, string>
                    {
                        { "refresh_token", refresh_token.tokenValue },
                        { "app_id", _config["ZaloManager:AppId"] },
                        { "grant_type", "refresh_token" }
                    };

                var content = new FormUrlEncodedContent(data);

                var response = await httpClient.PostAsync(Endpoint, content);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Post To Get Access Token Fail");
                }

                string token = await response.Content.ReadAsStringAsync();

                var token_Result = await response.Content.ReadFromJsonAsync<MemberAccessTokenModel>();

                if (token_Result != null)
                {
                    // Update Access Token

                    var accessToken = await _tokenService.GetTokenById("access_token");
                    accessToken.tokenValue = token_Result.access_token;
                    accessToken.expireTime = DateTime.Now.AddHours(24);
                    await _tokenService.UpdateToken(accessToken);

                    //Update RefreshToken
                    refresh_token.tokenValue = token_Result.refresh_token;
                    refresh_token.expireTime = DateTime.Now.AddDays(29);
                    await _tokenService.UpdateToken(refresh_token);

                    return accessToken;
                }

                return null;
            }
        }
    }
}
