using AutoMapper;
using DataModels.Entities;
using DataViewModels.Requests;
using DataViewModels.Requests.MemberInfo;
using DataViewModels.Responses;

namespace BusinessServices.AutoMapperProfile
{
    public class MemberMapperProfile : Profile
    {
        public MemberMapperProfile()
        {
            CreateMap<MemberInfo, MemberResponseModel>();

            CreateMap<CreateMemberModel, MemberInfo>();

            CreateMap<MemberInfo, UpdateMemberModel>();

            CreateMap<UpdateMemberModel, MemberInfo>();
        }
    }
}
