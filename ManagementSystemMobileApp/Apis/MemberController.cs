using BusinessServices.Repositories;
using BusinessServices.Repositories.MemberServices;
using DataViewModels.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemMobileApp.Apis
{
    [ApiController]
    public class MemberController(IMemberAdminServices _memberServices, IZaloTokenServices _tokenServices) : ControllerBase
    {
        [HttpPost]
        [Route("/api/member_webhook")]
        public async Task<ActionResult> GetZaloInfo([FromBody] CustomerFollowEvent followEvent)
        {
            try
            {
                var newMember = await _memberServices.CreateNewMember(followEvent);
                if (newMember != null)
                {
                    var accessToken = await _tokenServices.GetAccessToken();
                    using (var httpClient = new HttpClient())
                    {
                        string endpoint = "https://openapi.zalo.me/v3.0/oa/message/cs";
                        httpClient.DefaultRequestHeaders.Add("access_token", accessToken);
                        ZaloTextMessage message = new ZaloTextMessage();
                        message.message.text = $"Thành viên mới đăng ký: {newMember.memberName}";
                        message.recipient.user_id = "2910676812089540619";
                        var response = await httpClient.PostAsJsonAsync(endpoint, message);
                        message.recipient.user_id = "2037863224857417512";
                        response = await httpClient.PostAsJsonAsync(endpoint, message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok();
        }
    }
    public class Message
    {
        public string text { get; set; }
    }

    public class Recipient
    {
        public string user_id { get; set; }
    }

    public class ZaloTextMessage
    {
        public Recipient recipient { get; set; } = new Recipient();
        public Message message { get; set; } = new Message();
    }
}
