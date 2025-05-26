namespace DataModels.Filter
{
    public class TransactionFilter : BaseFilter
    {
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string? memberId { get; set; }
        public string? restaurantId { get; set; }
        public int transactionType { get; set; } = 0;
    }
}
