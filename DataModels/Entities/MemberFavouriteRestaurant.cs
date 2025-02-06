namespace DataModels.Entities
{
    public class MemberFavouriteRestaurant
    {
        public Guid memberInfoId { get; set; }
        public MemberInfo memberInfo { get; set; }
        public Guid restaurantInfoId { get; set; }
        public RestaurantInfo restaurantInfo { get; set; }
    }
}
