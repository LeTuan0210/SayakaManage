using AutoMapper;
using DataServices.Interfaces;
using DataServices.Repository;
using DataViewModels.Requests.RestaurantInfo;
using DataViewModels.Responses.Restaurant;

namespace BusinessServices.Repositories.RestaurantServices
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
        public Task<RestaurantResponseModel> CreateNewRestaurantAsync(CreateRestaurantRequestModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRestaurantAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<RestaurantResponseModel> GetRestaurantByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateRestaurantRequestModel> GetUpdateRestaurantAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<RestaurantResponseModel> UpdateRestaurantAsync(UpdateRestaurantRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
