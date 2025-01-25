using DataModels.Entities;
using DataModels.Filter;
using DataServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataServices.Repository
{
    public class RestaurantAreaDataServices(ApplicationDbContext _context) : IRestaurantAreaDataServices
    {
        public async Task<RestaurantArea> CreateNewAreaAsync(RestaurantArea Area)
        {
            _context.RestaurantAreas.Add(Area);
            await _context.SaveChangesAsync();
            return Area;
        }

        public async Task<List<RestaurantArea>> GetAllAreaAsync(AreaFilter filter)
        {
            var query = _context.RestaurantAreas.AsQueryable();
            if (filter.SortByName == 1)
                query = query.OrderBy(x => x.areaAlias);
            var result = await query.ToListAsync();
            return result;
        }

        public async Task<RestaurantArea> GetAreaAsync(Guid id)
        {
            var result = await _context.RestaurantAreas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NullReferenceException();

            return result;
        }

        public async Task<RestaurantArea> GetAreaAsync(string alias)
        {
            var result = await _context.RestaurantAreas.AsNoTracking().FirstOrDefaultAsync(x => x.areaAlias == alias);

            if (result == null)
                throw new NullReferenceException();

            return result;
        }

        public async Task<RestaurantArea> UpdateAreaAsync(RestaurantArea Area)
        {
            _context.RestaurantAreas.Update(Area);

            await _context.SaveChangesAsync();

            return Area;
        }

        public async Task<bool> DeleteAreaAsync(Guid id)
        {
            var Area = await _context.RestaurantAreas.FirstOrDefaultAsync(p => p.Id == id);

            if (Area == null)
                return false;

            _context.RestaurantAreas.Remove(Area);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
