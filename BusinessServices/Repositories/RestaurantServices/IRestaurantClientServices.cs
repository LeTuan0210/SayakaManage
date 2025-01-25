using DataModels.Filter;
using DataViewModels.Responses;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public interface IRestaurantClientServices : IRestaurantBaseServices
    {
        Task<RestaurantResponseModel> GetRestaurantByAliasAsync(string alias);
        Task<List<RestaurantResponseModel>> GetRelatedRestaurantAsync(RestaurantFilter filter);
    }
}
