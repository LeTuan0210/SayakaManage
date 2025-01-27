using DataModels.Entities;
using DataModels.Filter;
using DataServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataServices.Repository
{
    public class SystemPromotionDataServices(ApplicationDbContext _context) : ISystemPromotionDataServices
    {
        public async Task<SystemPromotion> CreateNewPromotionAsync(SystemPromotion promotion)
        {
            promotion.Id = Guid.NewGuid();

            _context.SystemPromotions.Add(promotion);

            await _context.SaveChangesAsync();
            
            return promotion;
        }        

        public Task<List<SystemPromotion>> GetAllPromotionAsync(PromotionFilter filter)
        {
            var query = _context.SystemPromotions.Where(promotion => promotion.promotionName.ToLower().Contains(filter.FilterName.ToLower())).AsQueryable();

            switch(filter.SortByName)
            {
                case 1:
                    if (filter.SortByCreateDate)
                        query = query.OrderByDescending(promotion => promotion.createDate).ThenBy(promotion => promotion.promotionAlias);
                    else
                        query = query.OrderBy(promotion => promotion.promotionAlias);
                    break;
                case 2:
                    if (filter.SortByCreateDate)
                        query = query.OrderByDescending(promotion => promotion.createDate).ThenByDescending(promotion => promotion.promotionAlias);
                    else
                        query = query.OrderByDescending(promotion => promotion.promotionAlias);
                    break;
                default:
                    if (filter.SortByCreateDate)
                        query = query.OrderByDescending(promotion => promotion.createDate);
                    else
                        query = query.OrderBy(promotion => promotion.createDate);
                    break;
            }

            if (filter.ExceptItem != null)
                query = query.Where(x => x.Id != filter.ExceptItem);            

            int itemSkip = (filter.PageNumber - 1) * filter.PageSize;

            var result = query.Skip(itemSkip).Take(filter.PageSize).AsNoTracking().ToListAsync();

            return result;
        }

        public async Task<SystemPromotion> GetPromotionAsync(Guid id)
        {
            var result = await _context.SystemPromotions.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NullReferenceException();

            return result;
        }

        public async Task<SystemPromotion> GetPromotionAsync(string alias)
        {
            var result = await _context.SystemPromotions.AsNoTracking().FirstOrDefaultAsync(x => x.promotionAlias == alias);

            if (result == null)
                throw new NullReferenceException();

            return result;
        }

        public async Task<SystemPromotion> UpdatePromotionAsync(SystemPromotion promotion)
        {
            _context.SystemPromotions.Update(promotion);

            await _context.SaveChangesAsync();

            return promotion;
        }
        public async Task<bool> DeletePromotionAsync(Guid id)
        {
            var promotion = await _context.SystemPromotions.FirstOrDefaultAsync(p => p.Id == id);

            if (promotion == null)
                return false;

            _context.SystemPromotions.Remove(promotion);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<SystemPromotion>> CreateListPromotion(List<SystemPromotion> promotions)
        {
            _context.SystemPromotions.AddRange(promotions);

            await _context.SaveChangesAsync();
            
            return promotions;
        }
    }
}
