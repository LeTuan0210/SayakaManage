using Azure;
using DataServices.Interfaces;
using DataViewModels.Requests;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using DataModels.Filter;
using DataModels.Entities;
using Extensions;
using DataViewModels.Responses.ZaloPromotion;
using Newtonsoft.Json;
using System.Text;

namespace BusinessServices.Repositories
{
    public class ZaloServices(IZaloTokenServices _tokenServices,
                                IConfiguration _config, 
                                IMemberDataServices _memberServices, 
                                IZaloPromotionDataServices _promotionServices) : IZaloServices
    {
        public async Task<bool> SendAllPromotion()
        {            
            try
            {
                var nowDate = DateTime.Now;

                var promotion = await _promotionServices.GetDefaultPromotion();

                if (promotion.lastSend.Date == nowDate.Date)
                    return false;

                if (nowDate.Hour != 11)
                    return false;                

                var memberList = await _memberServices.GetAllMemberAsync(new MemberFilter { isSentPromotion = 1 });                

                var sendResults = await SendListPromotion(memberList, promotion);

                string textToAdmin = "";

                foreach (var groupResult in sendResults.GroupBy(x => x))
                {
                    textToAdmin += "\n - " + groupResult.Key + ": " + groupResult.Count();
                }

                await SendTextToAdmin($"{DateTime.Now.ToString("dd/MM/yyyy")}:{textToAdmin}\n - Tin khuyến mãi cập nhật lần cuối: {promotion.updateDate.ToString("dd/MM/yyyy")}");

                _promotionServices.UpdateLastTimeSend();
                
                var countMember = _memberServices.CountUnsendMember();
                
                if(countMember == 0)
                {
                    _memberServices.ResetMemberSend();
                    await SendTextToAdmin("Đã gửi tất cả khách hàng. Reset Danh Sách");
                }    

                return true;
            }
            catch (Exception ex) 
            {
                await SendTextToAdmin(ex.Message);
                return false;
            }
        }

        public async Task<ZaloResultSendMessage> SendPromotionToMember(SendPromotionRequestModel model, string accessToken)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string Endpoint = _config["ZaloManager:SendPromotionUri"];

                    client.DefaultRequestHeaders.Add("access_token", accessToken);    

                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore // Bỏ qua các trường null
                    };

                    var jsonObject = JsonConvert.SerializeObject(model, settings);

                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");

                    var result = await client.PostAsync(Endpoint, content);

                    if(!result.IsSuccessStatusCode)
                    {
                        return null;
                    }

                    var sentResult = await result.Content.ReadFromJsonAsync<ZaloResultSendMessage>();

                    return sentResult;
                }
            }
            catch
            {
                return null;
            }
        }

        async Task<List<string>> SendListPromotion(List<MemberInfo> memberList, ZaloPromotion promotion)
        {

            List<string> sendResults = new List<string>();

            var message = new SendPromotionRequestModel();

            message.message = GetPromotionMessage(promotion);

            var accessToken = await _tokenServices.GetAccessToken();

            foreach (var member in memberList)
            {
                message.recipient.user_id = member.user_Id;

                var result = await SendPromotionToMember(message, accessToken);

                if (result != null)
                    sendResults.Add(result.message);

                member.isSendedPromotion = true;

                try
                {
                    await _memberServices.UpdateMemberAsync(member);
                }
                catch { }
            }

            return sendResults;
        }

        ZaloPromotionMessage GetPromotionMessage(ZaloPromotion promotion)
        {
            ZaloPromotionMessage message = new ZaloPromotionMessage();

            List<ZaloElementRequestModel> elements = new List<ZaloElementRequestModel>();

            List<ZaloButtonRequestModel> buttons = new List<ZaloButtonRequestModel>();

            foreach(var item in promotion.elements)
            {
                ZaloElementRequestModel model = new ZaloElementRequestModel();
                switch(item.type)
                {
                    case "banner":
                        model.type = ZaloElementType.Banner;
                        model.image_url = item.content;
                        break;
                    default:
                        model.type = item.type;
                        model.content = item.content.Replace("\n", "<br>");
                        model.align = "left";
                        break;
                }
                elements.Add(model);
            }    

            message.attachment.payload.elements = elements;

            if(promotion.buttons != null)
            {
                foreach (var button in promotion.buttons)
                {
                    ZaloButtonRequestModel zaloButton = new ZaloButtonRequestModel();
                    zaloButton.type = button.type;
                    zaloButton.title = button.title;
                    zaloButton.payload = new ZaloButtonPayload { url = button.payload };
                    zaloButton.image_icon = button.imageIcon;
                    buttons.Add(zaloButton);
                }                
            }
            message.attachment.payload.buttons = buttons;

            return message;
        }

        public async Task<bool> SendTextToAdmin(string text)
        {
            List<string> admins = _config.GetSection("ZaloManager:Admin_Id").Get<List<string>>();

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

        public async Task SendTestPromotion()
        {
            try
            {
                var promotion = await _promotionServices.GetDefaultPromotion();

                var message = new SendPromotionRequestModel();                

                message.message = GetPromotionMessage(promotion);

                var accessToken = await _tokenServices.GetAccessToken();

                message.recipient.user_id = "4733319382129802719";

                //_promotionServices.UpdateLastTimeSend();
                
                await SendPromotionToMember(message, accessToken);

                //await SendTextToAdmin($" - {DateTime.Now.ToString("dd/MM/yyyy")}: Đã gửi tin nhắn quảng cáo đến khách hàng thành viên Zalo.\n - Tin khuyến mãi cập nhật lần cuối: {promotion.updateDate.ToString("dd/MM/yyyy")}");

            }
            catch { }
        }
    }
}
