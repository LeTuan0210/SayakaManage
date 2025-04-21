using DataModels.Entities;
using DataModels.Filter;
using DataViewModels.Requests;

namespace DataServices.Interfaces
{
    public interface IMemberDataServices
    {
        Task<List<MemberInfo>> GetAllMemberAsync(MemberFilter filter);
        Task<MemberInfo> GetMemberAsync(string user_id_by_app);
        Task<MemberInfo> CreateNewMemberAsync(MemberInfo member);
        Task<List<MemberInfo>> CreateListMemberAsync(List<MemberInfo> member);
        Task<MemberInfo> UpdateMemberAsync(MemberInfo menu);
        Task<bool> DeleteMemberAsync(Guid id);
        int CountUnsendMember();
        void ResetMemberSend();
    }
}
