using DataModels.Filter;
using DataViewModels.Responses.SystemPromotion;

namespace BusinessServices.Repositories.SystemPromotionServices
{
    public interface ISystemPromotionClientServices : ISystemPromotionBaseServices
    {
        Task<SystemPromotionResponseModel> GetPromotionByAliasAsync(string alias);
        Task<List<SystemPromotionResponseModel>> GetRelatedPromotion(PromotionFilter filter);
    }
}
