using AutoMapper;
using DataServices.Interfaces;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public class ZaloPromotionServices(IZaloPromotionDataServices _services, IMapper _mapper) : IZaloPromotionServices
    {
        public Task<ZaloPromotionResponseModel> CreatePromotion()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ZaloPromotionResponseModel>> GetAllPromotions()
        {
            try
            {
                var result = await _services.GetAllPromotion();
                return _mapper.Map<List<ZaloPromotionResponseModel>>(result);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<ZaloPromotionResponseModel> GetDefaultPromotion()
        {
            try
            {
                var result = await _services.GetDefaultPromotion();
                return _mapper.Map<ZaloPromotionResponseModel>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public Task<ZaloPromotionResponseModel> GetPromotionById()
        {
            throw new NotImplementedException();
        }
    }
}
