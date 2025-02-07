using AutoMapper;
using DataModels.Entities;
using DataServices.Interfaces;
using DataViewModels.Requests;
using DataViewModels.Requests.MemberInfo;
using DataViewModels.Responses;
using DataViewModels.Responses.MemberInfo;
using System.Net.Http.Json;

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

        public async Task<MemberResponseModel> CreateNewMember(CustomerFollowEvent followEvent)
        {
            // Check Member is Exist in Database. If Exist and User is active, return this User

            var memberInfo = await _memberServices.GetMemberAsync(followEvent.user_id_by_app);

            if (memberInfo != null)
            {
                memberInfo.isActive = followEvent.event_name == "follow";

                await _memberServices.UpdateMemberAsync(memberInfo);

                return null;
            }

            // Get OA Access Token, Call API check this Member and Update

            string access_Token = await _tokenServices.GetAccessToken();

            using (var client = new HttpClient())
            {
                string Endpoint = $"https://openapi.zalo.me/v3.0/oa/user/detail?data={{\"user_id\":\"{followEvent.follower.id}\"}}";

                client.DefaultRequestHeaders.Add("access_token", access_Token);

                var followerInfo = await client.GetFromJsonAsync<ZaloOAUserDetailModel>(Endpoint);

                if (followerInfo.error != 0)
                    return null;

                var createUserModel = new CreateMemberModel
                {
                    user_Id = followerInfo.data.user_id,
                    user_Id_By_App = followerInfo.data.user_id_by_app,
                    memberName = followerInfo.data.display_name,
                    isActive = followerInfo.data.user_is_follower,
                    memberAvatar = followerInfo.data.avatar,
                };

                var newMember = await _memberServices.CreateNewMemberAsync(_mapper.Map<MemberInfo>(createUserModel));

                return _mapper.Map<MemberResponseModel>(newMember);
            }
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

        public async Task<MemberInfo> UpdateMemberAsync(MemberInfo member)
        {
            try
            {
                await _memberServices.UpdateMemberAsync(member);
                return member;
            }
            catch
            {
                return null;
            }
        }
    }
}
