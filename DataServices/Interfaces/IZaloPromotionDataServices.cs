using DataModels.Entities;

namespace DataServices.Interfaces
{
    public interface IZaloPromotionDataServices
    {
        Task<List<ZaloPromotion>> GetAllPromotion();
        Task<ZaloPromotion> GetDefaultPromotion();
        Task<ZaloPromotion> GetPromotionById(Guid id);
        Task<ZaloPromotion> CreatePromotion(ZaloPromotion zaloPromotion);
        Task<ZaloPromotion> UpdatePromotion(ZaloPromotion zaloPromotion);
        void UpdateLastTimeSend();
        Task DeletePromotion(Guid id);
    }
}
