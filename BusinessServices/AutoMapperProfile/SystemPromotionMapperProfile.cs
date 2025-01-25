using AutoMapper;
using DataModels.Entities;
using DataViewModels.Requests;
using DataViewModels.Responses;

namespace BusinessServices.AutoMapperProfile
{
    public class SystemPromotionMapperProfile : Profile
    {
        public SystemPromotionMapperProfile() 
        {
            CreateMap<SystemPromotion, SystemPromotionResponseModel>();
            CreateMap<SystemPromotion, UpdateSystemPromotionRequestModel>();
            CreateMap<CreateSystemPromotionRequestModel,SystemPromotion>();
            CreateMap<UpdateSystemPromotionRequestModel, SystemPromotion>();
        }
    }
}
