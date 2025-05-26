namespace DataModels.Filter
{
    public class TransactionFilter : BaseFilter
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? memberId { get; set; }
        public string? restaurantId { get; set; }
        public int transactionType { get; set; } = 0;
    }
}
