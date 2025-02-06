using DataModels.Entities;

namespace BusinessServices.Repositories.MemberServices
{
    public class MemberBaseServices : IMemberBaseServices
    {

        Task<MemberInfo> IMemberBaseServices.GetMemberById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
