namespace DataViewModels.Requests
{
    public class CreateTransactionRequestModel
    {
        public required string memberId { get; set; } // Input Từ Form
        public required string cashierId { get; set; } // Lấy từ Local Storage
        public required string restaurantId { get; set; } // Lấy từ Local Storage
        public required string orderId { get; set; } // Input Từ Form
        public required int orderValue { get; set; } // Input Từ Form
    }
}
