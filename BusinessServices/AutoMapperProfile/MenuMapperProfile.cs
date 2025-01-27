using AutoMapper;
using DataModels.Entities;
using DataViewModels.Responses;

namespace BusinessServices.AutoMapperProfile
{
    internal class MenuMapperProfile : Profile
    {
        public MenuMapperProfile() 
        {
            CreateMap<RestaurantMenu, MenuResponseModel>();
        }
    }
}
