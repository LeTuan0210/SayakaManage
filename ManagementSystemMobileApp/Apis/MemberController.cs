using BusinessServices.Repositories;
using BusinessServices.Repositories.MemberServices;
using DataViewModels.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemMobileApp.Apis
{
    [ApiController]
    public class MemberController(IMemberAdminServices _memberServices, IZaloServices _zaloServices) : ControllerBase
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
                    await _zaloServices.SendTextToAdmin($"Thành viên mới đăng ký: {newMember.memberName}");
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
