﻿using BusinessServices.Repositories;
using DataViewModels.Requests;
using DataViewModels.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemMobileApp.Apis
{
    [ApiController]
    public class AuthController(IAuthServices _authServicses) : ControllerBase
    {
        [HttpPost]
        [Route("api/auth/create-user")]
        public async Task<ActionResult<ApiResponseModel>> CreateNewUser([FromBody] CreateUserModel createUser)
        {
            return Ok();
        }

        [HttpPost]
        [Route("api/auth/login")]
        public async Task<ActionResult<ApiResponseModel>> LoginUser([FromBody] LoginModel createUser)
        {
            try
            {
                var result = await _authServicses.LoginUser(createUser);

                if (result == null)
                    return BadRequest(new ApiResponseModel("Failure", "Login Fail. Please try again"));
                
                switch(result.position)
                {
                    case "Cashier":
                        var cashier = await _authServicses.GetCashierInfo(result.userId);
                        return Ok(new ApiResponseModel("Success", "User Login Successfully", cashier));

                    case "Accountant":
                        return Ok(new ApiResponseModel("Success", "User Login Successfully", result));

                    default:
                        return Ok(new ApiResponseModel("Success", "User Login Successfully", result));
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseModel("Failure", ex.Message));
            }
            
        }

        [HttpPost]
        [Route("api/auth/logout")]
        public async Task<ActionResult<ApiResponseModel>> LogoutUser([FromBody] LogoutModel user)
        {
            try
            {
                var result = await _authServicses.LogoutUser(user.token);

                if (!result)
                    return BadRequest(new ApiResponseModel("Failure", "Logout Fail. Please try again"));

                return Ok(new ApiResponseModel("Success", "User Log out"));

            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseModel("Failure", ex.Message));
            }

        }
    }
}
