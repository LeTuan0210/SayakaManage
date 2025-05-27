using AutoMapper;
using BusinessServices.Repositories;
using DataModels.Filter;
using DataViewModels.Requests;
using DataViewModels.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemMobileApp.Apis
{
    [ApiController]
    public class TransactionController(ITransactionAdminServices _transactionServices, IMapper _mapper, IZaloTokenServices _tokenServices) : ControllerBase
    {
        [HttpPost]
        [Route("/api/transactions/get-list-transactions")]
        public async Task<ActionResult<List<TransactionResponeModel>>> GetListTransaction([FromBody]TransactionRequestModel filter)
        {
            var result = await _transactionServices.GetTransactionsAsync(_mapper.Map<TransactionFilter>(filter));
            return Ok(result);
        }
        [HttpPost]
        [Route("/api/transactions/create-transaction")]
        public async Task<ActionResult<List<ApiResponseModel>>> CreateTransaction([FromBody] CreateTransactionRequestModel transaction)
        {
            try
            {
                var checkLogin = await CheckUserLoginAsync();

                if (!checkLogin)
                    return BadRequest(new ApiResponseModel("Failure", "User is not login in"));

                var newTransaction = await _transactionServices.CreateNewTransaction(transaction);

                return Ok(new ApiResponseModel("Success", "Created new transaction", transaction));
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
