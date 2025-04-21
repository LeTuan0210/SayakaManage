using BusinessServices.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace ManagementSystemMobileApp.Apis
{
    [ApiController]
    public class TokenController(IZaloTokenServices tokenServices) : ControllerBase
    {
        [HttpGet]
        [Route("/api/token/gettoken")]
        public async Task<string> GetToken()
        {
            var result = await tokenServices.GetAccessToken();

            return result ?? "";
        }
    }
}
