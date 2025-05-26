namespace DataViewModels.Requests
{
    public class TransactionRequestModel
    {
        public string? restaurantId { get; set; }
        public string? memberId { get; set; }
        public int page { get; set; } = 0;
        public int pageSize { get; set; }
        public int transactionType { get; set; } = 0;
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
    }
}
