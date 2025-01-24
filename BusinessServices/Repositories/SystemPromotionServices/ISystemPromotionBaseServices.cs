using DataModels.Filter;
using DataViewModels.Responses.SystemPromotion;

namespace BusinessServices.Repositories.SystemPromotionServices
{
    public interface ISystemPromotionBaseServices
    {
        Task<List<SystemPromotionResponseModel>> GetAllPromotionAsync(PromotionFilter filter);              
    }
}
