using DataViewModels.Requests;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public interface ITransactionAdminServices : ITransactionBaseServices
    {
        Task<TransactionResponeModel> CreateNewTransaction(CreateTransactionRequestModel transaction);
        Task<TransactionResponeModel> CreateMemberUsePointTransaction(MemberUsePointRequestModel transaction);
    }
}
