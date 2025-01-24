using AutoMapper;
using DataModels.Entities;
using DataViewModels.Requests.SystemPromotion;
using DataViewModels.Responses.SystemPromotion;

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
