using DataModels.Entities;
using DataModels.Filter;
using DataServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataServices.Repository
{
    public class TransactionDataServices(ApplicationDbContext _context) : ITransactionDataServices
    {
        public Task<int> CheckMemberPointAsync(string userId)
        {
            var result = _context.MemberTransactions.Where(x => x.memberInfouser_Id == userId).SumAsync(x => x.transactionValue);
            return result;
        }

        public async Task<MemberTransaction> CreateNewTransaction(MemberTransaction memberTransaction)
        {
            _context.MemberTransactions.Add(memberTransaction);
            await _context.SaveChangesAsync();
            return memberTransaction;
        }

        public async Task<List<MemberTransaction>> GetAllTransactions(TransactionFilter transactionFilter)
        {
            var query = _context.MemberTransactions.AsQueryable();

            if(!string.IsNullOrEmpty(transactionFilter.memberId)) // Filter By MemberId
            {
                query = query.Where(transaction => transaction.memberInfouser_Id == transactionFilter.memberId);
            }

            if(!string.IsNullOrEmpty(transactionFilter.memberPhone))
            {
                query = query.Where(transaction => transaction.memberInfo.memberPhone.Contains(transactionFilter.memberPhone));
            }    

            if (!string.IsNullOrEmpty(transactionFilter.restaurantId))
            {
                query = query.Where(transaction => transaction.restaurantId.ToString() == transactionFilter.restaurantId);
            }                           

            switch(transactionFilter.transactionType)
            {
                case 1:
                    query = query.Where(x => x.transactionValue > 0);
                    break;
                case 2:
                    query = query.Where(x => x.transactionValue < 0);
                    break;
            }

            if(transactionFilter.startDate != null || transactionFilter.endDate != null && transactionFilter.startDate >= transactionFilter.endDate)
            {
                query = query.Where(transaction => transaction.transactionDate.Date >= transactionFilter.startDate.Value.Date && transaction.transactionDate.Date <= transactionFilter.endDate.Value.Date);
            }
            else if (transactionFilter.startDate == null && transactionFilter.endDate != null)
            {
                query = query.Where(transaction =>  transaction.transactionDate.Date <= transactionFilter.endDate.Value.Date);
            }
            else if(transactionFilter.startDate != null && transactionFilter.endDate == null)
            {
                query = query.Where(transaction => transaction.transactionDate.Date >= transactionFilter.startDate.Value.Date);
            }

            query = query.OrderByDescending(x => x.transactionDate).Skip((transactionFilter.PageNumber - 1) * transactionFilter.PageSize).Take(transactionFilter.PageSize);
             
            return await query.Include(x => x.memberInfo).Include(x => x.restaurant).ToListAsync();
        }

        public async Task<MemberTransaction> GetTransactionById(int id)
        {
            return await _context.MemberTransactions.Include(x => x.memberInfo).Include(x => x.restaurant).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
