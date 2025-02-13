namespace DataModels.Entities
{
    public class CustomerOrder
    {
        public Guid id { get; set; }
        public DateTime orderDate { get; set; } = DateTime.Now.AddHours(1);
        public Guid restaurantId { get; set; }     
        public RestaurantInfo restaurant { get; set; }
        public string? memberId { get; set; }
        public MemberInfo? member { get; set; }
        public int countCustomer { get; set; }
        public string customerName { get; set; }
        public string customerPhone { get; set; }
        public string customerEmail { get; set; }
        public string orderNote { get; set; }
    }
}
