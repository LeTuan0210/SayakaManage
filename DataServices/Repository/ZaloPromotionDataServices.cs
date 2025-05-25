using DataModels.Entities;
using DataServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataServices.Repository
{
    public class ZaloPromotionDataServices(ApplicationDbContext _context) : IZaloPromotionDataServices
    {
        public async Task<ZaloPromotion> CreatePromotion(ZaloPromotion zaloPromotion)
        {
            _context.ZaloPromotions.Add(zaloPromotion);
            await _context.SaveChangesAsync();
            return zaloPromotion;
        }

        public async Task DeletePromotion(Guid id)
        {
            var result = await _context.ZaloPromotions.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                result.isEnable = false;
                _context.Update(result);
                await _context.SaveChangesAsync();
            }
            throw new ArgumentNullException();
        }

        public async Task<List<ZaloPromotion>> GetAllPromotion()
        {
            var query = _context.ZaloPromotions.Include(x => x.buttons).Include(x => x.elements).AsQueryable();
            query = query.Where(x => x.isEnable);
            var result = await query.ToListAsync();
            return result;
        }

        public async Task<ZaloPromotion> GetDefaultPromotion()
        {
            var result = await _context.ZaloPromotions.Include(x => x.buttons).Include(x => x.elements).FirstOrDefaultAsync(x => x.isDefault);

            if(result != null)
                return result;

            return null;
        }

        public Task<ZaloPromotion> GetPromotionById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateLastTimeSend()
        {
            try
            {
                _context.Database.ExecuteSqlRaw($"Update ZaloPromotions set lastSend='{DateTime.Now.ToShortDateString()}'");
            }
            catch { }
        }

        public Task<ZaloPromotion> UpdatePromotion(ZaloPromotion zaloPromotion)
        {
            throw new NotImplementedException();
        }
    }
}
