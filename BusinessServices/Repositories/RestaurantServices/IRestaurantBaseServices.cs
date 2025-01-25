using DataModels.Filter;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public interface IRestaurantBaseServices
    {
        Task<List<RestaurantResponseModel>> GetAllRestaurantsAsync(RestaurantFilter filter);
    }
}
