using DataViewModels.Requests;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public interface IReservationClientServices : IReservationBaseServices
    {
        Task<CreateReservationModel> GetCustomerInfoReservation();
        Task<ReservationResponseModel> CreateNewReservation(CreateReservationModel model);
    }
}
