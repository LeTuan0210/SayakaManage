using DataModels.Entities;
using DataViewModels.Requests;
using DataViewModels.Responses;

namespace BusinessServices.Repositories.MemberServices
{
    public interface IMemberAdminServices : IMemberBaseServices
    {
        Task<List<MemberInfo>> GetAllMemberAsync();
        Task<MemberResponseModel> CreateNewMember(CustomerFollowEvent followEvent);
        Task<MemberInfo> DisableAccount(CustomerFollowEvent followEvent);
        Task<MemberInfo> UpdateMemberAsync(MemberInfo member);
        Task<MemberInfo> DeleteMemberAsync(string id);
    }
}
