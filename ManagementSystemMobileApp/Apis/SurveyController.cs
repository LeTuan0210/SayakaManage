using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using UAParser;

namespace ManagementSystemMobileApp.Apis
{
    [ApiController]
    public class SurveyController : ControllerBase
    {
        [Route("api/survey")]
        [HttpPost]
        public async Task<ActionResult> PostSurveyAnswer([FromBody]AnswerModel answer)
        {
            HttpContext.Response.Headers.AccessControlAllowHeaders = "*";
            HttpContext.Response.Headers.AccessControlAllowOrigin = "*";
            HttpContext.Response.Headers.AccessControlAllowMethods = "*";
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            var client = new HttpClient(handler);

            var result = answer.ToAnswerString();

            var uaParser = Parser.GetDefault();

            try
            {
                var clientInfo = uaParser.Parse(HttpContext.Request.Headers["User-Agent"]);
                result.Add(new AnswerRequestModel(0, clientInfo.Device.Family));
                result.Add(new AnswerRequestModel(0, clientInfo.OS.Family));
                result.Add(new AnswerRequestModel(0, clientInfo.UA.Family));
                result.Add(new AnswerRequestModel(0, HttpContext.Request.Headers["User-Agent"]));
            }
            catch
            {

            }

            var response = await client.PostAsJsonAsync<List<AnswerRequestModel>>("https://test.sayaka.vn/api/survey", result);

            if(response.IsSuccessStatusCode)
                return Ok();

            return BadRequest( await response.Content.ReadAsStringAsync());
        }
        [HttpPost]
        [Route("api/tracking-survey")]
        public async Task<ActionResult> TrackingUserStep([FromBody] TrackingModel userTracking)
        {
            try
            {
                HttpContext.Response.Headers.AccessControlAllowHeaders = "*";
                HttpContext.Response.Headers.AccessControlAllowOrigin = "*";
                HttpContext.Response.Headers.AccessControlAllowMethods = "*";
                var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                };

                var client = new HttpClient(handler);

                var response = await client.PostAsJsonAsync<TrackingModel>("https://test.sayaka.vn/api/tracking-survey", userTracking);

                if (response.IsSuccessStatusCode)
                    return Ok();

                return BadRequest(await response.Content.ReadAsStringAsync());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
    public sealed class TrackingModel
    {
        public required string userId { get; set; }
        [Range(1, 7)]
        public required int Step { get; set; }
        [Range(0, int.MaxValue)]
        public required int visitCount { get; set; }

    }
    public sealed class AnswerModel
    {
        public string age { get; set; } = "Chưa trả lời";
        public string cusname { get; set; } = "Chưa trả lời";
        public string brandDifference { get; set; } = "Chưa trả lời";
        public string experienceRating { get; set; } = "Chưa trả lời";
        public string email { get; set; } = "Chưa trả lời";
        public string gift { get; set; } = "Chưa trả lời";
        public string interestedInCombo { get; set; } = "Chưa trả lời";
        public string job { get; set; } = "Chưa trả lời";
        public string location { get; set; } = "Chưa trả lời";
        public string lunchBudget { get; set; } = "Chưa trả lời";
        public string phone { get; set; } = "Chưa trả lời";
        public string preferredLocation { get; set; } = "Chưa trả lời";

        public string reason { get; set; } = "Chưa trả lời";
        public string recommendChanChan { get; set; } = "Chưa trả lời";
        public string suggestedImprovement { get; set; } = "Chưa trả lời";
        public string visitCount { get; set; } = "Chưa trả lời";
        public string visitDay { get; set; } = "Chưa trả lời";
        public string visitTime { get; set; } = "Chưa trả lời";
        public string visitWith { get; set; } = "Chưa trả lời";
        public string wantsDelivery { get; set; } = "Chưa trả lời";
        public string userId { get; set; } = "Chưa Update Tracking";
        public override string ToString()
        {
            return age + job;
        }
        public List<AnswerRequestModel> ToAnswerString()
        {
            List<AnswerRequestModel> list = new List<AnswerRequestModel>();
            list.Add(new AnswerRequestModel(19, cusname));
            list.Add(new AnswerRequestModel(1, age));
            list.Add(new AnswerRequestModel(20, phone));
            list.Add(new AnswerRequestModel(10, email));
            list.Add(new AnswerRequestModel(2, job));
            list.Add(new AnswerRequestModel(3, location));
            list.Add(new AnswerRequestModel(4, lunchBudget));
            list.Add(new AnswerRequestModel(5, visitCount));
            list.Add(new AnswerRequestModel(6, visitTime));
            list.Add(new AnswerRequestModel(7, visitWith));
            list.Add(new AnswerRequestModel(8, reason));
            list.Add(new AnswerRequestModel(12, brandDifference));
            list.Add(new AnswerRequestModel(13, experienceRating));
            list.Add(new AnswerRequestModel(14, recommendChanChan));
            list.Add(new AnswerRequestModel(15, preferredLocation));
            list.Add(new AnswerRequestModel(16, wantsDelivery));
            list.Add(new AnswerRequestModel(17, interestedInCombo));
            list.Add(new AnswerRequestModel(18, suggestedImprovement));
            list.Add(new AnswerRequestModel(21, gift));
            list.Add(new AnswerRequestModel(100, userId));
            return list;
        }
    }
    public class AnswerRequestModel
    {
        public AnswerRequestModel()
        {

        }
        public AnswerRequestModel(int questionId, string answer)
        {
            QuestionId = questionId;
            Answer = answer;
        }

        public int QuestionId { get; set; }
        public string Answer { get; set; }
    }
}