using DataModels.Filter;
using DataViewModels.Responses.Restaurant;
using DataViewModels.Responses.SystemPromotion;

namespace BusinessServices.Repositories.RestaurantServices
{
    public interface IRestaurantClientServices : IRestaurantBaseServices
    {
        Task<RestaurantResponseModel> GetRestaurantByAliasAsync(string alias);
        Task<List<RestaurantResponseModel>> GetRelatedRestaurantAsync(PromotionFilter filter);
    }
}
