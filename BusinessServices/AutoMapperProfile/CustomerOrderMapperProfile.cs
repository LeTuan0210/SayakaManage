using AutoMapper;
using DataModels.Entities;
using DataViewModels.Requests;
using DataViewModels.Responses;

namespace BusinessServices.AutoMapperProfile
{
    public class CustomerOrderMapperProfile : Profile
    {
        public CustomerOrderMapperProfile()
        {
            CreateMap<MemberResponseModel, CreateReservationModel>()
                .ForMember(dest => dest.memberId, src => src.MapFrom(src => src.user_Id))
                .ForMember(dest => dest.customerName, src => src.MapFrom(src => src.memberName))
                .ForMember(dest => dest.customerPhone, src => src.MapFrom(src => src.memberPhone))
                .ForMember(dest => dest.customerEmail, src => src.MapFrom(src => src.memberEmail));

            CreateMap<CreateReservationModel, CustomerOrder>();

            CreateMap<CustomerOrder, ReservationResponseModel>();
        }
    }
}
