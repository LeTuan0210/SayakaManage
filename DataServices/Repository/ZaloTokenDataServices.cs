using DataModels.Entities;
using DataServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataServices.Repository
{
    public class ZaloTokenDataServices(ApplicationDbContext _context) : IZaloTokenDataServices
    {
        public async Task<List<ZaloToken>> GetAllToken()
        {
            var result = await _context.ZaloTokens.ToListAsync();

            return result;
        }

        public async Task<ZaloToken> GetTokenById(string id)
        {
            var result = await _context.ZaloTokens.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<ZaloToken> UpdateToken(ZaloToken token)
        {
            _context.ZaloTokens.Update(token);
            await _context.SaveChangesAsync();
            return token;
        }
    }
}
