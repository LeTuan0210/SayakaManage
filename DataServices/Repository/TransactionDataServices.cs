using DataModels.Entities;
using DataModels.Filter;
using DataServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace DataServices.Repository
{
    public class TransactionDataServices(ApplicationDbContext _context) : ITransactionDataServices
    {
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

            return await query.ToListAsync();
        }
    }
}
