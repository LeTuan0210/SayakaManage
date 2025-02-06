using DataViewModels.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemWebAdmin.Apis
{
    [ApiController]
    public class MemberController : ControllerBase
    {
        [HttpPost]
        [Route("/api/member_webhook")]
        public async Task<ActionResult> GetZaloInfo([FromBody] CustomerFollowEvent followEvent)
        {
            try
            {
                switch (followEvent.event_name)
                {
                    case "":

                        break;
                    case "/":
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            return Ok();
        }
    }
}
