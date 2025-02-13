using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public interface IReservationBaseServices
    {
        Task<ReservationResponseModel> GetReservationById(Guid id);
    }
}
