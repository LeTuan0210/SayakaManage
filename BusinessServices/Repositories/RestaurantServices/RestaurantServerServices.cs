using AutoMapper;
using DataModels.Entities;
using DataServices.Interfaces;
using DataViewModels.Requests;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public class RestaurantServerServices : RestaurantBaseServices, IRestaurantServerServices
    {
        private readonly IRestaurantDataServices _restaurantServices;
        private readonly IMapper _mapper;

        public RestaurantServerServices(IRestaurantDataServices restaurantServices, IMapper mapper) : base(restaurantServices, mapper)
        {
            _restaurantServices = restaurantServices;
            _mapper = mapper;
        }
        public async Task<RestaurantResponseModel> CreateNewRestaurantAsync(CreateRestaurantRequestModel model)
        {
            try
            {
                var createModel = _mapper.Map<RestaurantInfo>(model);

                createModel = await _restaurantServices.CreateNewRestaurantAsync(createModel);

                return _mapper.Map<RestaurantResponseModel>(createModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }        

        public async Task<RestaurantResponseModel> GetRestaurantByIdAsync(Guid id)
        {
            try
            {
                var result = await _restaurantServices.GetRestaurantAsync(id);

                return _mapper.Map<RestaurantResponseModel>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<UpdateRestaurantRequestModel> GetUpdateRestaurantAsync(Guid id)
        {
            try
            {

                var result = await _restaurantServices.GetRestaurantAsync(id);

                return _mapper.Map<UpdateRestaurantRequestModel>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<RestaurantResponseModel> UpdateRestaurantAsync(UpdateRestaurantRequestModel model)
        {
            try
            {
                var updateModel = await _restaurantServices.GetRestaurantAsync(model.Id);

                if (updateModel == null)
                    return null;

                _mapper.Map(model, updateModel);

                updateModel = await _restaurantServices.UpdateRestaurantAsync(updateModel);

                return _mapper.Map<RestaurantResponseModel>(updateModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<bool> DeleteRestaurantAsync(Guid id)
        {
            try
            {
                await _restaurantServices.DeleteRestaurantAsync(id);

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
