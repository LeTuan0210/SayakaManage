using DataModels.Entities;

namespace BusinessServices.Repositories
{
    public interface IMemberBaseServices
    {
        Task<MemberInfo> GetMemberById(string id);
        
    }
}
