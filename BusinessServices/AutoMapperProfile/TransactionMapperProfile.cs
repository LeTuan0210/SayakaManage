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
            CreateMap<CreateTransactionRequestModel, MemberTransaction>()
                .ForMember(dest => dest.memberInfouser_Id, src => src.MapFrom(src => src.memberId))
                .ForMember(dest => dest.cashierId, src => src.MapFrom(src => Guid.Parse(src.cashierId)))
                .ForMember(dest => dest.restaurantId, src => src.MapFrom(src => Guid.Parse(src.restaurantId)))
                .ForMember(dest => dest.orderValue, src => src.MapFrom(src => src.orderValue))
                .ForMember(dest => dest.orderId, src => src.MapFrom(src => src.orderId));
        }
    }
}
