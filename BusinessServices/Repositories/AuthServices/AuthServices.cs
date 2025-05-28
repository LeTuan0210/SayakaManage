using BusinessServices.Extensions;
using DataServices;
using DataServices.Interfaces;
using DataViewModels.Requests;
using DataViewModels.Responses;
using Microsoft.AspNetCore.Identity;

namespace BusinessServices.Repositories
{
    public class AuthServices(UserManager<ApplicationUser> _userManager, IZaloTokenServices _tokenServices, IUserDataServices _userServices) : IAuthServices
    {
        public async Task<SystemUserResponseModel> CheckUserInfo(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user == null)
                    throw new NullReferenceException("Don't have this user name");

                return new CashierResponseModel { userId = user.Id, userName = user.UserName, position = user.Position ?? "Không có", userFullName = user.UserFullname, restaurantId = user.RestaurantId.ToString() ?? "Không có", restaurantName = user.Restaurant.restaurantName };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SystemUserResponseModel> CreateNewUser(CreateUserModel createUser)
        {
            try
            {
                var systemUser = new ApplicationUser();

                systemUser.Position = createUser.Position;
                systemUser.Email = createUser.Email;
                systemUser.PhoneNumber = createUser.PhoneNumber;
                systemUser.UserName = createUser.UserName;
                systemUser.RestaurantId = !string.IsNullOrEmpty(createUser.RestaurantId) ? Guid.Parse(createUser.RestaurantId) : Guid.Empty;
                systemUser.UserFullname = createUser.UserFullName;

                var result = await _userManager.CreateAsync(systemUser, createUser.Password);

                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                var user = await _userManager.FindByNameAsync(createUser.UserName);

                if (user == null)
                    throw new NullReferenceException("Don't have this user name");

                return new CashierResponseModel { userId = user.Id, userFullName = user.UserFullname, userName = user.UserName, restaurantId = user.RestaurantId.ToString() ?? "Không có", restaurantName = user.Restaurant != null ? user.Restaurant.restaurantName : "Không có" };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CashierResponseModel> GetCashierInfo(string userName)
        {
            try
            {
                var user = await _userServices.GetUserByUsername(userName);

                if (user == null)
                    throw new NullReferenceException("Don't have this user name");

                return new CashierResponseModel { userId = user.Id, userName = user.UserName, position = user.Position ?? "Không có", userFullName = user.UserFullname, restaurantId = user.RestaurantId.ToString() ?? "Không có", restaurantName = user.Restaurant.restaurantName };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SystemUserResponseModel> LoginUser(LoginModel loginModel)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(loginModel.username);

                if (user == null)
                    throw new NullReferenceException("Don't have this user name");

                var checkPassword = await _userManager.CheckPasswordAsync(user, loginModel.password);

                if(!checkPassword)
                    throw new Exception("Sai thông tin đăng nhập. Vui lòng kiểm tra lại.");

                var createToken = await _tokenServices.CreateTokenAsync(user.Id);

                if(!createToken)
                    throw new Exception("Không thể tạo token đăng nhập, vui lòng liên hệ Quản trị viên");

                return new SystemUserResponseModel { userId = user.Id, userFullName = user.UserFullname, userName = loginModel.username, position = user.Position ?? "Không có" };
                                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> LogoutUser(string userId)
        {
            try
            {
                var result = await _tokenServices.DeteleTokenAsync(userId);
                return result;
            }
            catch
            {
                return false;
            }
        }
    }
}
