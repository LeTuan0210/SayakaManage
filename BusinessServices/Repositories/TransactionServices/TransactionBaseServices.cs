using AutoMapper;
using DataModels.Filter;
using DataServices.Interfaces;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public class TransactionBaseServices(ITransactionDataServices _transactionServices, IMapper _mapper) : ITransactionBaseServices
    {
        public async Task<List<TransactionResponeModel>> GetTransactionsAsync(TransactionFilter filter)
        {
            try
            {
                var result = await _transactionServices.GetAllTransactions(filter);
                return _mapper.Map<List<TransactionResponeModel>>(result);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                return new List<TransactionResponeModel>();
            }
        }
    }
}
