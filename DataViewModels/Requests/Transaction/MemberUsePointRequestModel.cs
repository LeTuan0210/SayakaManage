namespace DataViewModels.Requests
{
    public class MemberUsePointRequestModel
    {
        public required string memberId { get; set; } // Input Từ Form
        public required string cashierId { get; set; } // Lấy từ Local Storage
        public required string restaurantId { get; set; } // Lấy từ Local Storage
        public required int pointUse { get; set; } // Input Từ Form
    }
}
