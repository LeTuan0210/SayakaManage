using DataServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataServices.Repository
{
    public class UserDataServices(ApplicationDbContext _context) : IUserDataServices
    {
        public async Task<ApplicationUser> GetUserByUsername(string username)
        {
            var user = await _context.Users.Include(x => x.Restaurant).AsNoTracking().FirstOrDefaultAsync(x => x.UserName == username);
            return user;
        }
    }
}
