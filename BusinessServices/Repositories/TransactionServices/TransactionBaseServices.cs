using AutoMapper;
using DataModels.Filter;
using DataServices;
using DataServices.Interfaces;
using DataViewModels.Responses;
using Microsoft.AspNetCore.Identity;

namespace BusinessServices.Repositories
{
    public class TransactionBaseServices(ITransactionDataServices _transactionServices, IMapper _mapper, UserManager<ApplicationUser> _userManager) : ITransactionBaseServices
    {
        public async Task<int> CheckMemberPoint(string userId)
        {
            try
            {
                var memberPoint = await _transactionServices.CheckMemberPointAsync(userId);
                return memberPoint;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

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
