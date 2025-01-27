namespace DataModels.Entities
{
    public class RestaurantMenu
    {
        public Guid Id { get; set; }
        public string menuName { get; set; }
        public string menuAliasName { get; set; }
        public string menuDescription { get; set; } = "Updating";
        public int menuPrice { get; set; }
        public List<string> menuImages { get; set; } = new List<string>();
        public string menuType { get; set; }
    }
}
