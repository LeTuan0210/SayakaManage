namespace DataModels.Entities
{
    public class MemberTransaction
    {
        public int Id { get; set; }
        public string memberInfouser_Id { get; set; }
        public MemberInfo memberInfo { get; set; }
        public Guid cashierId { get; set; }
        public Guid restaurantId { get; set; }
        public RestaurantInfo restaurant { get; set; }
        public string transactionTitle { get; set; }
        public string transactionDescription { get; set; }
        public int transactionValue { get; set; }
        public DateTime transactionDate { get; set; } = DateTime.Now;
        public string? orderId { get; set; }
    }
}
