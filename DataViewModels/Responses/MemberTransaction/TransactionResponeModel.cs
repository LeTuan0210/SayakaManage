namespace DataViewModels.Responses
{
    public class TransactionResponeModel
    {
        public int Id { get; set; }
        public string memberId { get; set; }
        public string memberName { get; set; }
        public string memberPhone { get; set; }
        public string restaurant { get; set; }
        public string restaurantId { get; set; }
        public string transactionTitle { get; set; }
        public string transactionDescription { get; set; }
        public int transactionValue { get; set; }
        public int orderValue { get; set; }
        public DateTime transactionDate { get; set; }
        public string? orderId { get; set; }
    }
}
