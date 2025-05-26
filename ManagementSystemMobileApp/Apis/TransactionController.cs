using AutoMapper;
using BusinessServices.Repositories;
using DataModels.Filter;
using DataViewModels.Requests;
using DataViewModels.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemMobileApp.Apis
{
    [ApiController]
    public class TransactionController(ITransactionClientServices _transactionServices, IMapper _mapper) : ControllerBase
    {
        [HttpPost]
        [Route("/api/transactions/get-list-transactions")]
        public async Task<ActionResult<List<TransactionResponeModel>>> GetListTransaction([FromBody]TransactionRequestModel filter)
        {
            var result = await _transactionServices.GetTransactionsAsync(_mapper.Map<TransactionFilter>(filter));
            return Ok(result);
        }
    }
}
