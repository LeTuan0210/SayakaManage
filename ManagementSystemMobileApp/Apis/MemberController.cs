using BusinessServices.Repositories.MemberServices;
using DataViewModels.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemMobileApp.Apis
{
    [ApiController]
    public class MemberController(IMemberAdminServices _memberServices) : ControllerBase
    {
        [HttpPost]
        [Route("/api/member_webhook")]
        public async Task<ActionResult> GetZaloInfo([FromBody] CustomerFollowEvent followEvent)
        {
            try
            {
                await _memberServices.CreateNewMember(followEvent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok();
        }
    }
}
