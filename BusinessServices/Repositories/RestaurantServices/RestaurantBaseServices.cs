using AutoMapper;
using DataModels.Filter;
using DataServices.Interfaces;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public class RestaurantBaseServices(IRestaurantDataServices _restaurantService, IMapper _mapper) : IRestaurantBaseServices
    {
        public async Task<List<RestaurantResponseModel>> GetAllRestaurantsAsync(RestaurantFilter filter)
        {
            try
            {
                var listRestaurant = await _restaurantService.GetAllRestaurantAsync(filter);
                var result = _mapper.Map<List<RestaurantResponseModel>>(listRestaurant);
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
