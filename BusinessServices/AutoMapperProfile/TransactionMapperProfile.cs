using AutoMapper;
using DataModels.Entities;
using DataViewModels.Responses;

namespace BusinessServices.AutoMapperProfile
{
    public class TransactionMapperProfile : Profile
    {
        public TransactionMapperProfile()
        {
            CreateMap<MemberTransaction, TransactionResponeModel>()
                .ForMember(dest => dest.memberId, src => src.MapFrom(src => src.memberInfouser_Id))
                .ForMember(dest => dest.memberName, src => src.MapFrom(src => src.memberInfo.memberName))
                .ForMember(dest => dest.memberPhone, src => src.MapFrom(src => src.memberInfo.memberPhone))
                .ForMember(dest => dest.memberId, src => src.MapFrom(src => src.restaurant.restaurantName));
        }
    }
}
