namespace DataViewModels.Responses
{
    public class RestaurantResponseModel
    {
        public Guid Id { get; set; }
        public string restaurantName { get; set; }
        public string restaurantDescription { get; set; }
        public string restaurantAliasName { get; set; }
        public string restaurantAddress { get; set; }
        public string restaurantPhone { get; set; }
        public string restaurantArea { get; set; }
        public string restaurantCity { get; set; }
        public string restaurantAvatarLink { get; set; }
        public double restaurantLatitude { get; set; }
        public double restaurantLongitude { get; set; }
        public string restaurantEmbedMap { get; set; }
    }
}
