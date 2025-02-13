using DataViewModels.Requests;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public interface IMemberClientServices : IMemberBaseServices
    {
        Task AuthenticationMember(string authorizeCode = "");
        Task<MemberResponseModel> GetMemberInfo();
        Task<UpdateMemberModel> GetUpdateMemberModel();
        Task<MemberResponseModel> ChangeFavouriteRestaurant(Guid restaurantId, bool status);
        Task<MemberResponseModel> UpdateMemberInfoByUser(UpdateMemberModel model);
        bool IsAuthenticated();
        string IsCompleteInfomation();
    }
}
