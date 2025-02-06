using AutoMapper;
using DataViewModels.Responses;
using System.Reflection;

namespace BusinessServices.AutoMapperProfile
{
    public class MemberMapperProfile : Profile
    {
        public MemberMapperProfile()
        {
            CreateMap<MemberInfo, MemberResponseModel>();
        }
    }
}
