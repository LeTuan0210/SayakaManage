using DataModels.Entities;
using DataServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataServices.Repository
{
    public class ReservationDataServices(ApplicationDbContext _context) : IReservationDataServices
    {
        public async Task<CustomerOrder> CreateNewCustomerOrder(CustomerOrder order)
        {
            _context.CustomerOrders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<CustomerOrder> GetOrderAsync(Guid id)
        {
            var result = await _context.CustomerOrders.Include(x => x.restaurant).AsNoTracking().FirstOrDefaultAsync(x => x.id == id);

            return result;
        }
    }
}
