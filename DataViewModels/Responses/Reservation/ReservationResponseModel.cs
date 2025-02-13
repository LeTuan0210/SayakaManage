namespace DataViewModels.Responses
{
    public class ReservationResponseModel
    {
        public Guid id { get; set; }
        public DateTime orderDate { get; set; }
        public RestaurantResponseModel restaurant { get; set; }
        public int countCustomer { get; set; }
        public string customerName { get; set; }
        public string customerPhone { get; set; }
        public string customerEmail { get; set; }
        public string orderNote { get; set; }
    }
}
