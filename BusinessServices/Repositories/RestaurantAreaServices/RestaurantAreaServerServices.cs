using AutoMapper;
using DataModels.Entities;
using DataServices.Interfaces;
using DataViewModels.Requests;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public class RestaurantAreaServerServices : RestaurantAreaBaseServices, IRestaurantAreaServerServices
    {
        private readonly IRestaurantAreaDataServices _areaService;
        private readonly IMapper _mapper;
        public RestaurantAreaServerServices(IRestaurantAreaDataServices areaService, IMapper mapper) : base(areaService, mapper)
        {
            _areaService = areaService;
            _mapper = mapper;
        }
        public async Task<RestaurantAreaResponseModel> CreateNewAreaAsync(CreateAreaRequestModel model)
        {
            try
            {
                var createModel = _mapper.Map<RestaurantArea>(model);

                createModel = await _areaService.CreateNewAreaAsync(createModel);

                return _mapper.Map<RestaurantAreaResponseModel>(createModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<UpdateAreaRequestModel> GetUpdateAreaAsync(Guid id)
        {
            try
            {
                var result = await _areaService.GetAreaAsync(id);

                return _mapper.Map<UpdateAreaRequestModel>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<RestaurantAreaResponseModel> UpdateAreaAsync(UpdateAreaRequestModel model)
        {
            try
            {
                var updateModel = await _areaService.GetAreaAsync(model.Id);

                if (updateModel == null)
                    return null;

                _mapper.Map(model, updateModel);

                updateModel = await _areaService.UpdateAreaAsync(updateModel);

                return _mapper.Map<RestaurantAreaResponseModel>(updateModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> DeleteAreaAsync(Guid id)
        {
            try
            {
                await _areaService.DeleteAreaAsync(id);

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
