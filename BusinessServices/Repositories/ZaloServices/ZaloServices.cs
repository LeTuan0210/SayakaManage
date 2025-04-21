
using Azure;
using DataViewModels.Requests;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Json;

namespace BusinessServices.Repositories
{
    public class ZaloServices(IZaloTokenServices _tokenServices, IConfiguration _config) : IZaloServices
    {
        public async Task<bool> SendTextToAdmin(string text)
        {
            List<string> admins = _config.GetSection("Admin_Id").Get<List<string>>();

            try
            {
                var accessToken = await _tokenServices.GetAccessToken();

                using (var client = new HttpClient())
                {
                    string Endpoint = _config["ZaloManager:SendTextUri"];

                    client.DefaultRequestHeaders.Add("access_token", accessToken);

                    TextMessageModel message = new TextMessageModel();

                    message.message.text = text;

                    foreach (var admin in admins)
                    {
                        message.recipient.user_id = admin;
                        var response = await client.PostAsJsonAsync(Endpoint, message);
                    }
                }

                return true;
                    
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public async Task<bool> SendTextToGroup(string text)
        {
            try
            {
                var accessToken = await _tokenServices.GetAccessToken();

                using (var client = new HttpClient())
                {
                    string Endpoint = _config["ZaloManager:SendGroupText"];

                    client.DefaultRequestHeaders.Add("access_token", accessToken);

                    TextMessageModel message = new TextMessageModel();

                    message.recipient.group_id = _config["ZaloManager:Group_Id"];

                    message.message.text = text;

                    var response = await client.PostAsJsonAsync(Endpoint, message);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
