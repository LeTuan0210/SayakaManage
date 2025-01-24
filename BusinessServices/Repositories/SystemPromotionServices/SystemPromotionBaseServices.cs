using AutoMapper;
using DataModels.Filter;
using DataServices.Repository;
using DataViewModels.Responses.SystemPromotion;

namespace BusinessServices.Repositories.SystemPromotionServices
{
    public class SystemPromotionBaseServices(SystemPromotionDataServices _promotionService, IMapper _mapper) : ISystemPromotionBaseServices
    {
        public async Task<List<SystemPromotionResponseModel>> GetAllPromotionAsync(PromotionFilter filter)
        {
            try
            {
                var listPromotion = await _promotionService.GetAllPromotionAsync(filter);

                var result = _mapper.Map<List<SystemPromotionResponseModel>>(listPromotion);

                return result;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}
