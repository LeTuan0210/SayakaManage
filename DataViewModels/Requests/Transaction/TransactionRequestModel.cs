namespace DataViewModels.Requests
{
    public class TransactionRequestModel
    {
        public string? restaurantId { get; set; }
        public string? memberId { get; set; }
        public string? memberPhone { get; set; }
        public int page { get; set; } = 0;
        public int pageSize { get; set; } = 20;
        public int transactionType { get; set; } = 0;
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
    }
}
