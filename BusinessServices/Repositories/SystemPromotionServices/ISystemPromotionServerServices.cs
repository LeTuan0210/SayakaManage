using DataViewModels.Requests.SystemPromotion;
using DataViewModels.Responses.SystemPromotion;

namespace BusinessServices.Repositories.SystemPromotionServices
{
    public interface ISystemPromotionServerServices : ISystemPromotionBaseServices
    {
        Task<SystemPromotionResponseModel> CreateNewPromotionAsync(CreateSystemPromotionRequestModel model);
        Task<SystemPromotionResponseModel> GetPromotionByIdAsync(Guid id);
        Task<UpdateSystemPromotionRequestModel> GetUpdatePromotionAsync(Guid id);
        Task<SystemPromotionResponseModel> UpdatePromotionAsync(UpdateSystemPromotionRequestModel model);
        Task<bool> DeletePromotionAsync(Guid id);
    }
}
