using AutoMapper;
using DataModels.Entities;
using DataServices.Interfaces;
using DataViewModels.Requests;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public class ReservationClientServices : ReservationBaseServices, IReservationClientServices
    {
        private readonly IReservationDataServices _dataServices;
        private readonly IMemberClientServices _memberClientServices;
        private readonly IRestaurantDataServices _restaurantDataServices;
        private readonly IZaloServices _zaloServices;
        private readonly IMapper _mapper;
        public ReservationClientServices(IMemberClientServices memberClientServices,
                                            IMapper mapper,
                                            IReservationDataServices dataServices,
                                            IRestaurantDataServices restaurantServices,
                                            IZaloServices zaloServices) : base(dataServices, mapper)
        {
            _memberClientServices = memberClientServices;
            _mapper = mapper;
            _dataServices = dataServices;
            _restaurantDataServices = restaurantServices;
            _zaloServices = zaloServices;
        }

        public async Task<ReservationResponseModel> CreateNewReservation(CreateReservationModel model)
        {
            var newOrder = _mapper.Map<CustomerOrder>(model);
            
            newOrder = await _dataServices.CreateNewCustomerOrder(newOrder);

            if(newOrder == null)
            {
                return null;
            }

            var restaurant = await _restaurantDataServices.GetRestaurantAsync(model.restaurantId);

            string message = $"Thông tin đặt bàn: \n - Khách hàng: {newOrder.customerName} \n - Số Điện Thoại: {newOrder.customerPhone} \n - Số khách: {newOrder.countCustomer} \n - Nhà hàng: {restaurant.restaurantName} \n - Thời gian: {newOrder.orderDate.ToString("dd/MM/yyyy - HH:mm")} \n - Lời nhắn: {newOrder.orderNote}";

            await _zaloServices.SendTextToAdmin(message);

            return _mapper.Map<ReservationResponseModel>(newOrder);
        }

        public async Task<CreateReservationModel> GetCustomerInfoReservation()
        {
            var memberInfo = await _memberClientServices.GetMemberInfo();

            if (memberInfo == null)
            {
                return null;
            }
            return _mapper.Map<CreateReservationModel>(memberInfo);
        }
    }
}
