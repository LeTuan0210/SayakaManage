using AutoMapper;
using DataModels.Filter;
using DataServices.Interfaces;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public class SystemPromotionClientServices : SystemPromotionBaseServices, ISystemPromotionClientServices
    {
        private readonly IMapper _mapper;
        private readonly ISystemPromotionDataServices _promotionServices;
        public SystemPromotionClientServices(ISystemPromotionDataServices promotionServices, IMapper mapper) : base(promotionServices, mapper)
        {
            _promotionServices = promotionServices;
            _mapper = mapper;
        }
        public async Task<SystemPromotionResponseModel> GetPromotionByAliasAsync(string alias)
        {
            try
            {
                var result = await _promotionServices.GetPromotionAsync(alias);

                return _mapper.Map<SystemPromotionResponseModel>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<SystemPromotionResponseModel>> GetRelatedPromotion(PromotionFilter filter)
        {
            try
            {
                var listPromotion = await _promotionServices.GetAllPromotionAsync(filter);

                var result = _mapper.Map<List<SystemPromotionResponseModel>>(listPromotion);

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
