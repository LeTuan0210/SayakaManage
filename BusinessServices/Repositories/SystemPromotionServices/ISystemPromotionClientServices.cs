using DataModels.Filter;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public interface ISystemPromotionClientServices : ISystemPromotionBaseServices
    {
        Task<SystemPromotionResponseModel> GetPromotionByAliasAsync(string alias);
        Task<List<SystemPromotionResponseModel>> GetRelatedPromotion(PromotionFilter filter);
    }
}
