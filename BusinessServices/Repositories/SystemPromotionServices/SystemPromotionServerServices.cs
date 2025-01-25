using AutoMapper;
using DataModels.Entities;
using DataServices.Interfaces;
using DataViewModels.Requests;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public class SystemPromotionServerServices : SystemPromotionBaseServices, ISystemPromotionServerServices
    {
        private readonly IMapper _mapper;
        private readonly ISystemPromotionDataServices _promotionServices;
        public SystemPromotionServerServices(ISystemPromotionDataServices promotionServices, IMapper mapper) : base(promotionServices, mapper)
        {
            _promotionServices = promotionServices;
            _mapper = mapper;
        }
        public async Task<SystemPromotionResponseModel> CreateNewPromotionAsync(CreateSystemPromotionRequestModel model)
        {
            try
            {
                var createModel = _mapper.Map<SystemPromotion>(model);

                createModel = await _promotionServices.CreateNewPromotionAsync(createModel);

                return _mapper.Map<SystemPromotionResponseModel>(createModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<SystemPromotionResponseModel> GetPromotionByIdAsync(Guid id)
        {
            try
            {
                var result = await _promotionServices.GetPromotionAsync(id);

                return _mapper.Map<SystemPromotionResponseModel>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<UpdateSystemPromotionRequestModel> GetUpdatePromotionAsync(Guid id)
        {
            try
            {

                var result = await _promotionServices.GetPromotionAsync(id);

                return _mapper.Map<UpdateSystemPromotionRequestModel>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<SystemPromotionResponseModel> UpdatePromotionAsync(UpdateSystemPromotionRequestModel model)
        {
            try
            {
                var updateModel = await _promotionServices.GetPromotionAsync(model.Id);

                if (updateModel == null)
                    return null;

                _mapper.Map(model, updateModel);

                updateModel = await _promotionServices.UpdatePromotionAsync(updateModel);

                return _mapper.Map<SystemPromotionResponseModel>(updateModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<bool> DeletePromotionAsync(Guid id)
        {
            try
            {
                await _promotionServices.DeletePromotionAsync(id);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
