using AutoMapper;
using DataModels.Entities;
using DataViewModels.Responses;

namespace BusinessServices.AutoMapperProfile
{
    public class ZaloPromotionMapperProfile : Profile
    {
        public ZaloPromotionMapperProfile()
        {
            CreateMap<ZaloPromotion, ZaloPromotionResponseModel>();
            CreateMap<ZaloPromotionButton, ZaloButtonResponseModel>();
            CreateMap<ZaloPromotionElement, ZaloElementResponseModel>();
        }
    }
}
