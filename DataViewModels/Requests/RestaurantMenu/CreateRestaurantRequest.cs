namespace DataViewModels.Requests.RestaurantMenu
{
    public class CreateRestaurantRequest
    {
        public string menuName { get; set; }
        public string menuDescription { get; set; }
        public int menuPrice { get; set; }
        public List<string> menuImages { get; set; } = new List<string>();
        public string menuType { get; set; }
    }
}
