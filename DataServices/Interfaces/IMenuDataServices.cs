using DataModels.Entities;
using DataModels.Filter;

namespace DataServices.Interfaces
{
    public interface IMenuDataServices
    {
        Task<List<RestaurantMenu>> GetAllMenuAsync(MenuFilter filter);
        Task<RestaurantMenu> GetMenuAsync(Guid id);
        Task<RestaurantMenu> GetMenuAsync(string alias);
        Task<RestaurantMenu> CreateNewMenuAsync(RestaurantMenu menu);
        Task<RestaurantMenu> UpdateMenuAsync(RestaurantMenu menu);
        Task<bool> DeleteMenuAsync(Guid id);
    }
}
