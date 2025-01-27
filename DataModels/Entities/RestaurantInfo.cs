namespace DataModels.Entities
{
    public class RestaurantInfo
    {
        public Guid Id { get; set; }
        public string restaurantName { get; set; }
        public string restaurantDescription { get; set; } = "Updating";
        public string restaurantAliasName { get; set; }
        public string restaurantAddress { get; set; }
        public string restaurantPhone { get; set; }
        public string restaurantArea { get; set; }
        public string restaurantCity { get; set; } = "Updating";
        public string restaurantAvatarLink { get; set; } = "/images/restaurants/nha-hang.jpg";
    }
}
