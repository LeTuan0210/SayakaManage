using AutoMapper;
using DataModels.Filter;
using DataServices.Interfaces;
using DataServices.Repository;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public class SystemPromotionBaseServices: ISystemPromotionBaseServices
    {
        private readonly ISystemPromotionDataServices _promotionService;
        private readonly IMapper _mapper;
        public SystemPromotionBaseServices(ISystemPromotionDataServices promotionService, IMapper mapper)
        {
            _mapper = mapper;
            _promotionService = promotionService;
        }
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
