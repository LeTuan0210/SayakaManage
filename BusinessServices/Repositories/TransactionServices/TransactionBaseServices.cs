using AutoMapper;
using DataModels.Filter;
using DataServices.Repository;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public class TransactionBaseServices(TransactionDataServices _transactionServices, IMapper _mapper) : ITransactionBaseServices
    {
        public async Task<List<TransactionResponeModel>> GetTransactionsAsync(TransactionFilter filter)
        {
            try
            {
                var result = await _transactionServices.GetAllTransactions(filter);
                return null;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
    }
}
