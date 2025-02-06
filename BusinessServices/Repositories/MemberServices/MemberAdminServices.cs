using AutoMapper;
using DataModels.Entities;
using DataServices.Interfaces;
using DataViewModels.Requests;

namespace BusinessServices.Repositories.MemberServices
{
    public class MemberAdminServices : MemberBaseServices, IMemberAdminServices
    {
        private readonly IMemberDataServices _memberServices;
        private readonly IZaloTokenServices _tokenServices;
        private readonly IMapper _mapper;
        public MemberAdminServices(IMemberDataServices memberServices, IMapper mapper, IZaloTokenServices tokenServices)
        {
            _memberServices = memberServices;
            _mapper = mapper;
            _tokenServices = tokenServices;
        }
        
        public async Task<MemberInfo> CreateNewMember(CustomerFollowEvent followEvent)
        {
            // Check Member is Exist in Database. If Exist and User is active, return this User

            var memberInfo = await _memberServices.GetMemberAsync(followEvent.user_id_by_app);

            if (memberInfo != null)
            {
                memberInfo.isActive = followEvent.event_name == "follow";

                await _memberServices.UpdateMemberAsync(memberInfo);
                
                return memberInfo;
            }

            // Get OA Access Token, Call API check this Member and Update
            string access_Token = await _tokenServices.GetAccessToken();

            using (var client = new HttpClient())
            {
                string Endpoint = $"https://openapi.zalo.me/v3.0/oa/user/detail?data={{\"user_id\":\"4572947693969771653\"}}";
            }
            return null;
        }

        public Task<MemberInfo> DeleteMemberAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<MemberInfo> DisableAccount(CustomerFollowEvent followEvent)
        {
            throw new NotImplementedException();
        }

        public Task<List<MemberInfo>> GetAllMemberAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MemberInfo> UpdateMemberAsync(MemberInfo member)
        {
            throw new NotImplementedException();
        }
    }
}
