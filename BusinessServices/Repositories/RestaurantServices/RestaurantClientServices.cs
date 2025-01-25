using AutoMapper;
using DataModels.Filter;
using DataServices.Interfaces;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{   
    public class RestaurantClientServices : RestaurantBaseServices, IRestaurantClientServices
    {
        private readonly IRestaurantDataServices _restaurantServices;
        private readonly IMapper _mapper;

        public RestaurantClientServices(IRestaurantDataServices restaurantServices, IMapper mapper) : base(restaurantServices, mapper)
        {
            _restaurantServices = restaurantServices;
            _mapper = mapper;
        }
        public async Task<List<RestaurantResponseModel>> GetRelatedRestaurantAsync(RestaurantFilter filter)
        {
            try
            {
                var listRestaurant = await _restaurantServices.GetAllRestaurantAsync(filter);
                var result = _mapper.Map<List<RestaurantResponseModel>>(listRestaurant);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<RestaurantResponseModel> GetRestaurantByAliasAsync(string alias)
        {
            try
            {
                var result = await _restaurantServices.GetRestaurantAsync(alias);

                return _mapper.Map<RestaurantResponseModel>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
