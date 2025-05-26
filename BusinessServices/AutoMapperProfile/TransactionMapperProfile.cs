using AutoMapper;
using DataModels.Entities;
using DataModels.Filter;
using DataViewModels.Requests;
using DataViewModels.Responses;

namespace BusinessServices.AutoMapperProfile
{
    public class TransactionMapperProfile : Profile
    {
        public TransactionMapperProfile()
        {
            CreateMap<MemberTransaction, TransactionResponeModel>()
                .ForMember(dest => dest.memberId, src => src.MapFrom(src => src.memberInfouser_Id))
                .ForMember(dest => dest.memberName, src => src.MapFrom(src => src.memberInfo.memberName ?? ""))
                .ForMember(dest => dest.memberPhone, src => src.MapFrom(src => src.memberInfo.memberPhone ?? ""))
                .ForMember(dest => dest.restaurant, src => src.MapFrom(src => src.restaurant.restaurantName ?? ""))
                .ForMember(dest => dest.orderValue, src => src.MapFrom(src => src.orderValue));
            CreateMap<TransactionRequestModel, TransactionFilter>()
                .ForMember(dest => dest.PageSize, src => src.MapFrom(src => src.pageSize))
                .ForMember(dest => dest.PageNumber, src => src.MapFrom(src => src.page));
        }
    }
}
