using AutoMapper;
using DataServices.Interfaces;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public class ReservationBaseServices(IReservationDataServices _reservationService, IMapper _mapper) : IReservationBaseServices
    {
        public async Task<ReservationResponseModel> GetReservationById(Guid id)
        {
            try
            {
                var result = await _reservationService.GetOrderAsync(id);

                if (result == null)
                    return null;

                var order = _mapper.Map<ReservationResponseModel>(result);

                return order;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
