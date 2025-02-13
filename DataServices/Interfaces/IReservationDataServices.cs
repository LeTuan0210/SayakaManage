using DataModels.Entities;

namespace DataServices.Interfaces
{
    public interface IReservationDataServices
    {
        Task<CustomerOrder> CreateNewCustomerOrder(CustomerOrder order);
        Task<CustomerOrder> GetOrderAsync(Guid id);
    }
}
