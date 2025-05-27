using DataModels.Entities;
using DataModels.Filter;

namespace DataServices.Interfaces
{
    public interface ITransactionDataServices
    {
        Task<List<MemberTransaction>> GetAllTransactions(TransactionFilter transactionFilter);
        Task<MemberTransaction> CreateNewTransaction(MemberTransaction memberTransaction);
        Task<MemberTransaction> GetTransactionById(int id);
    }
}
