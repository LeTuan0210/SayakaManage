using AutoMapper;
using DataModels.Entities;
using DataViewModels.Requests.MemberInfo;
using DataViewModels.Responses;

namespace BusinessServices.AutoMapperProfile
{
    public class MemberMapperProfile : Profile
    {
        public MemberMapperProfile()
        {
            CreateMap<MemberInfo, MemberResponseModel>();

            CreateMap<CreateMemberModel, MemberInfo>()
                .ForMember(x => x.favouriteRestaurant, src => src.MapFrom(x => new List<RestaurantInfo>()));
        }
    }
}
