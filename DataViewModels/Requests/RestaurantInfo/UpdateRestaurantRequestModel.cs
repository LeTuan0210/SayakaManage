namespace DataViewModels.Requests.RestaurantInfo
{
    public class UpdateRestaurantRequestModel
    {
        public Guid Id { get; set; }
        public string restaurantName { get; set; }
        public string restaurantDescription { get; set; }
        public string restaurantAddress { get; set; }
        public string restaurantPhone { get; set; }
        public Guid restaurantAreaId { get; set; }
        public string restaurantCity { get; set; }
        public string restaurantAvatarLink { get; set; }
    }
}
