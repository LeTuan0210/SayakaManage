namespace DataModels.Entities
{
    public class RestaurantInfo
    {
        public Guid Id { get; set; }
        public string restaurantName { get; set; }
        public string restaurantDescription { get; set; }
        public string restaurantAliasName { get; set; }
        public string restaurantAddress { get; set; }
        public string restaurantPhone { get; set; }
        public Guid restaurantAreaId { get; set; }
        public RestaurantArea restaurantArea { get; set; }
        public string restaurantCity { get; set; }
        public string restaurantAvatarLink{  get; set; }
    }
}
