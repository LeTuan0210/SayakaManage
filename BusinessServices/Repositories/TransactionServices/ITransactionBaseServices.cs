using DataModels.Filter;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public interface ITransactionBaseServices
    {
        Task<List<TransactionResponeModel>> GetTransactionsAsync(TransactionFilter filter);
    }
}
