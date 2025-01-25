using DataModels.Entities;
using DataModels.Filter;

namespace DataServices.Interfaces
{
    public interface IRestaurantAreaDataServices
    {
        Task<List<RestaurantArea>> GetAllAreaAsync(AreaFilter filter);
        Task<RestaurantArea> GetAreaAsync(Guid id);
        Task<RestaurantArea> GetAreaAsync(string alias);
        Task<RestaurantArea> CreateNewAreaAsync(RestaurantArea Area);
        Task<RestaurantArea> UpdateAreaAsync(RestaurantArea Area);
        Task<bool> DeleteAreaAsync(Guid id);
    }
}
