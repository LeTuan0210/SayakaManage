using DataViewModels.Requests;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public interface IAuthServices
    {
        Task<SystemUserResponseModel> CreateNewUser(CreateUserModel user);
        Task<SystemUserResponseModel> LoginUser(LoginModel loginModel);
        Task<CashierResponseModel> GetCashierInfo(string userId);
        Task<SystemUserResponseModel> CheckUserInfo(string userId);
        Task<bool> LogoutUser(string userId);
    }
}
