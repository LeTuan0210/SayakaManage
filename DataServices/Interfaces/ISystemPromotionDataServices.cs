using DataModels.Entities;
using DataModels.Filter;

namespace DataServices.Interfaces
{
    public interface ISystemPromotionDataServices
    {
        Task<List<SystemPromotion>> GetAllPromotionAsync(PromotionFilter filter);
        Task<SystemPromotion> GetPromotionAsync(Guid id);
        Task<SystemPromotion> GetPromotionAsync(string alias);
        Task<SystemPromotion> CreateNewPromotionAsync(SystemPromotion promotion);
        Task<List<SystemPromotion>> CreateListPromotion(List<SystemPromotion> promotions);
        Task<SystemPromotion> UpdatePromotionAsync(SystemPromotion promotion);
        Task<bool> DeletePromotionAsync(Guid id);
    }
}
