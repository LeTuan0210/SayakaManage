using DataViewModels.Requests;
using DataViewModels.Responses.ZaloPromotion;

namespace BusinessServices.Repositories
{
    public interface IZaloServices
    {
        Task<bool> SendTextToAdmin(string text);
        Task<ZaloResultSendMessage> SendPromotionToMember(SendPromotionRequestModel model, string accessToken);
        Task<bool> SendAllPromotion();
        Task SendTestPromotion();
    }
}
