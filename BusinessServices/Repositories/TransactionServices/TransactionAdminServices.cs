using AutoMapper;
using BusinessServices.Repositories.MemberServices;
using DataModels.Entities;
using DataServices;
using DataServices.Interfaces;
using DataViewModels.Requests;
using DataViewModels.Responses;
using Microsoft.AspNetCore.Identity;

namespace BusinessServices.Repositories
{
    public class TransactionAdminServices : TransactionBaseServices, ITransactionAdminServices
    {
        private readonly ITransactionDataServices _transactionDataServices;
        private readonly IMapper _mapper;
        private readonly IMemberAdminServices _memberAdminServices;
        private readonly IRestaurantServerServices _restaurantServices;
        private readonly UserManager<ApplicationUser> _userManager;
        public TransactionAdminServices(ITransactionDataServices transactionServices, IMapper mapper, IMemberAdminServices memberAdminServices, IRestaurantServerServices restaurantServices, UserManager<ApplicationUser> userManager) : base(transactionServices, mapper, userManager)
        {
            _transactionDataServices = transactionServices;
            _mapper = mapper;
            _memberAdminServices = memberAdminServices;
            _restaurantServices = restaurantServices;
            _userManager = userManager;
        }

        public async Task<TransactionResponeModel> CreateMemberUsePointTransaction(MemberUsePointRequestModel transaction)
        {
            var user = await _userManager.FindByIdAsync(transaction.cashierId);

            if (user == null)
                throw new Exception("Không có nhân viên trùng với id này");

            var member = await _memberAdminServices.GetMemberById(transaction.memberId);

            if (member == null)
                throw new Exception("Không tìm thấy thành viên với Id này");

            var memberPoint = await _transactionDataServices.CheckMemberPointAsync(transaction.memberId);

            if(memberPoint < transaction.pointUse)
            {
                throw new Exception("Bạn không đủ Điểm để sử dụng.");
            }

            var restaurant = await _restaurantServices.GetRestaurantByIdAsync(Guid.Parse(transaction.restaurantId));

            if (restaurant == null)
                throw new Exception("Không có nhà hàng với mã này");

            var newTransaction = _mapper.Map<MemberTransaction>(transaction);

            newTransaction.transactionTitle = "Sử dụng Điểm";
            newTransaction.transactionDescription = $"Sử dụng {transaction.pointUse.ToString("N0")} tại {restaurant.restaurantName}.";
            newTransaction.orderValue = 0;
            newTransaction.orderId = "-";

            var result = await _transactionDataServices.CreateNewTransaction(newTransaction);

            return _mapper.Map<TransactionResponeModel>(result);
        }

        public async Task<TransactionResponeModel> CreateNewTransaction(CreateTransactionRequestModel transaction)
        {
            var user = await _userManager.FindByIdAsync(transaction.cashierId);

            if (user == null)
                throw new Exception("Không có nhân viên trùng với id này");

            var member = await _memberAdminServices.GetMemberById(transaction.memberId);

            if (member == null)
                throw new Exception("Không tìm thấy thành viên với Id này");

            var restaurant = await _restaurantServices.GetRestaurantByIdAsync(Guid.Parse(transaction.restaurantId));

            if (restaurant == null)
                throw new Exception("Không có nhà hàng với mã này");

            var newTransaction = _mapper.Map<MemberTransaction>(transaction);

            newTransaction.transactionTitle = "Tích điểm thành viên";
            newTransaction.transactionDescription = $"Tích điểm hóa đơn {transaction.orderId} tại {restaurant.restaurantName}.";
            newTransaction.transactionValue = newTransaction.orderValue / 100 * 8;

            var result = await _transactionDataServices.CreateNewTransaction(newTransaction);

            newTransaction = await _transactionDataServices.GetTransactionById(result.Id);

            return _mapper.Map<TransactionResponeModel>(newTransaction);
        }

    }
}
