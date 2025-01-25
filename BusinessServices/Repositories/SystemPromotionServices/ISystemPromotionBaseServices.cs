using DataModels.Filter;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public interface ISystemPromotionBaseServices
    {
        Task<List<SystemPromotionResponseModel>> GetAllPromotionAsync(PromotionFilter filter);              
    }
}
