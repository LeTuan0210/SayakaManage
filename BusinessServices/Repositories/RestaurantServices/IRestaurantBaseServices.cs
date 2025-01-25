using DataModels.Filter;
using DataViewModels.Responses.Restaurant;

namespace BusinessServices.Repositories.RestaurantServices
{
    public interface IRestaurantBaseServices
    {
        Task<List<RestaurantResponseModel>> GetAllRestaurantsAsync(RestaurantFilter filter);
    }
}
