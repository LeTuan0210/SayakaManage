using AutoMapper;
using DataModels.Filter;
using DataServices.Repository;
using DataViewModels.Responses.SystemPromotion;

namespace BusinessServices.Repositories.SystemPromotionServices
{
    public class SystemPromotionClientServices : SystemPromotionBaseServices, ISystemPromotionClientServices
    {
        private readonly IMapper _mapper;
        private readonly SystemPromotionDataServices _promotionServices;
        public SystemPromotionClientServices(SystemPromotionDataServices promotionServices, IMapper mapper) : base(promotionServices, mapper)
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
