using DataViewModels.Requests;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
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
