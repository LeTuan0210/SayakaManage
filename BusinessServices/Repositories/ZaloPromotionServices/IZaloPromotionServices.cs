using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public interface IZaloPromotionServices
    {
        Task<List<ZaloPromotionResponseModel>> GetAllPromotions();
        Task<ZaloPromotionResponseModel> GetDefaultPromotion();
        Task<ZaloPromotionResponseModel> GetPromotionById();
        Task<ZaloPromotionResponseModel> CreatePromotion();
    }
}
