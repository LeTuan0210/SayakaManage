using AutoMapper;
using DataModels.Entities;
using DataViewModels.Responses;

namespace BusinessServices.AutoMapperProfile
{
    internal class RestaurantMapperProfile : Profile
    {
        public RestaurantMapperProfile() 
        {
            CreateMap<RestaurantInfo, RestaurantResponseModel>();
        }
    }
}
