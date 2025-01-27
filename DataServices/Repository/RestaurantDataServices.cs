using DataModels.Entities;
using DataModels.Filter;
using DataServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataServices.Repository
{
    public class RestaurantDataServices(ApplicationDbContext _context) : IRestaurantDataServices
    {
        public async Task<RestaurantInfo> CreateNewRestaurantAsync(RestaurantInfo Restaurant)
        {
            _context.RestaurantInfos.Add(Restaurant);
            await _context.SaveChangesAsync();
            return Restaurant;
        }       

        public Task<List<RestaurantInfo>> GetAllRestaurantAsync(RestaurantFilter filter)
        {
            var query = _context.RestaurantInfos.AsQueryable();
            var result = query.OrderByDescending(x => x.restaurantArea).Skip(filter.skipItem).Take(filter.PageSize).ToListAsync();
            return result;
        }

        public async Task<RestaurantInfo> GetRestaurantAsync(Guid id)
        {
            var result = await _context.RestaurantInfos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NullReferenceException();

            return result;
        }

        public async Task<RestaurantInfo> GetRestaurantAsync(string alias)
        {
            var result = await _context.RestaurantInfos.AsNoTracking().FirstOrDefaultAsync(x => x.restaurantAliasName == alias);

            if (result == null)
                throw new NullReferenceException();

            return result;
        }

        public async Task<RestaurantInfo> UpdateRestaurantAsync(RestaurantInfo Restaurant)
        {
            _context.RestaurantInfos.Update(Restaurant);

            await _context.SaveChangesAsync();

            return Restaurant;
        }
        public async Task<bool> DeleteRestaurantAsync(Guid id)
        {
            var restaurant = await _context.RestaurantInfos.FirstOrDefaultAsync(p => p.Id == id);

            if (restaurant == null)
                return false;

            _context.RestaurantInfos.Remove(restaurant);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<RestaurantInfo>> CreateListRestaurants(List<RestaurantInfo> listRestaurants)
        {
            _context.AddRange(listRestaurants);

            await _context.SaveChangesAsync();
            
            return listRestaurants;
        }
    }
}
