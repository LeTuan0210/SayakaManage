using DataModels.Entities;
using DataModels.Filter;
using DataServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataServices.Repository
{
    public class MenuDataServices(ApplicationDbContext _context) : IMenuDataServices
    {
        public async Task<RestaurantMenu> CreateNewMenuAsync(RestaurantMenu menu)
        {
            _context.RestaurantMenus.Add(menu);
            await _context.SaveChangesAsync();
            return menu;
        }

        public async Task<List<RestaurantMenu>> GetAllMenuAsync(MenuFilter filter)
        {
            var query = _context.RestaurantMenus.AsQueryable();
            if (filter.SortByPrice)
                query = query.OrderBy(x => x.menuPrice).ThenBy(x => x.menuAliasName);
            var result = await query.ToListAsync();
            return result;
        }

        public async Task<RestaurantMenu> GetMenuAsync(Guid id)
        {
            var result = await _context.RestaurantMenus.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NullReferenceException();

            return result;
        }

        public async Task<RestaurantMenu> GetMenuAsync(string alias)
        {
            var result = await _context.RestaurantMenus.AsNoTracking().FirstOrDefaultAsync(x => x.menuAliasName == alias);

            if (result == null)
                throw new NullReferenceException();

            return result;
        }

        public async Task<RestaurantMenu> UpdateMenuAsync(RestaurantMenu menu)
        {
            _context.RestaurantMenus.Update(menu);

            await _context.SaveChangesAsync();

            return menu;
        }
        public async Task<bool> DeleteMenuAsync(Guid id)
        {
            var menu = await _context.RestaurantMenus.FirstOrDefaultAsync(p => p.Id == id);

            if (menu == null)
                return false;

            _context.RestaurantMenus.Remove(menu);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
