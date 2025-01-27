using DataModels.Entities;
using DataModels.Filter;

namespace DataServices.Interfaces
{
    public interface IRestaurantDataServices
    {
        Task<List<RestaurantInfo>> GetAllRestaurantAsync(RestaurantFilter filter);
        Task<RestaurantInfo> GetRestaurantAsync(Guid id);
        Task<RestaurantInfo> GetRestaurantAsync(string alias);
        Task<RestaurantInfo> CreateNewRestaurantAsync(RestaurantInfo Restaurant);
        Task<List<RestaurantInfo>> CreateListRestaurants(List<RestaurantInfo> listRestaurants);
        Task<RestaurantInfo> UpdateRestaurantAsync(RestaurantInfo Restaurant);
        Task<bool> DeleteRestaurantAsync(Guid id);
    }
}
