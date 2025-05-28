using AutoMapper;
using BusinessServices.Repositories;
using BusinessServices.Repositories.MemberServices;
using DataModels.Filter;
using DataViewModels.Requests;
using DataViewModels.Responses;
using Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace ManagementSystemMobileApp.Apis
{
    [ApiController]
    public class TransactionController(ITransactionAdminServices _transactionServices,
                                        IMapper _mapper,
                                        IZaloTokenServices _tokenServices,
                                        IMemberAdminServices _memberServices,
                                        IAuthServices _authServices) : ControllerBase
    {
        [HttpPost]
        [Route("/api/transactions/get-list-transactions")]
        public async Task<ActionResult<List<TransactionResponeModel>>> GetListTransaction([FromBody]TransactionRequestModel filter)
        {
            try
            {
                var checkLogin = await CheckUserLoginAsync();

                if (!checkLogin)
                    return BadRequest(new ApiResponseModel("Failure", "User is not login in"));

                var user = await _authServices.GetCashierInfo(HttpContext.Request.Headers["userId"]);

                if(user.position == "Cashier")
                {
                    filter.restaurantId = user.restaurantId;
                }

                var result = await _transactionServices.GetTransactionsAsync(_mapper.Map<TransactionFilter>(filter));

                return Ok(result);
            }
            catch (Exception ex) 
            {
                return BadRequest(new ApiResponseModel("Failure", ex.Message));
            }
        }

        [HttpPost]
        [Route("/api/transactions/create-transaction")]
        public async Task<ActionResult<ApiResponseModel>> CreateTransaction([FromBody] CreateTransactionRequestModel transaction)
        {
            try
            {
                var checkLogin = await CheckUserLoginAsync();

                if (!checkLogin)
                    return BadRequest(new ApiResponseModel("Failure", "User is not login in"));

                var newTransaction = await _transactionServices.CreateNewTransaction(transaction);

                return Ok(new ApiResponseModel("Success", "Created new transaction", newTransaction));
            }
            catch (Exception ex) 
            {
                return BadRequest(new ApiResponseModel("Failure", ex.Message));
            }
        }

        [HttpPost]
        [Route("/api/transactions/use-point")]
        public async Task<ActionResult<ApiResponseModel>> MemberUsePoint([FromBody] MemberUsePointRequestModel transaction)
        {
            try
            {
                var checkLogin = await CheckUserLoginAsync();

                if (!checkLogin)
                    return BadRequest(new ApiResponseModel("Failure", "User is not login in"));

                var newTransaction = await _transactionServices.CreateMemberUsePointTransaction(transaction);

                return Ok(new ApiResponseModel("Success", "Created new transaction", newTransaction));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseModel("Failure", ex.Message));
            }
        }

        [HttpGet]
        [Route("/api/member/{userId}")]
        public async Task<ActionResult<ApiResponseModel>> GetListTransaction(string userId)
        {
            try
            {
                var checkLogin = await CheckUserLoginAsync();

                if (!checkLogin)
                    return BadRequest(new ApiResponseModel("Failure", "User is not login in"));

                var member = await _memberServices.GetMemberById(userId);

                if (member == null)
                    return BadRequest(new ApiResponseModel("Failure", "Mã thành viên không hợp lệ"));

                dynamic myObject = new ExpandoObject();

                myObject.memberName = member.memberName;
                myObject.memberPhone = member.memberPhone.ToSecurePhoneNumber();
                myObject.memberPoint = await _transactionServices.CheckMemberPoint(userId);

                return Ok(new ApiResponseModel("Success", "Check Member Info Successfully", myObject));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseModel("Failure", ex.Message));
            }
        }

        async Task<bool> CheckUserLoginAsync()
        {
            var userId = HttpContext.Request.Headers["userId"];

            if (string.IsNullOrEmpty(userId))
                return false;

            var checkLogin = await _tokenServices.CheckTokenAsync(userId);

            return checkLogin;
        }
    }
}
