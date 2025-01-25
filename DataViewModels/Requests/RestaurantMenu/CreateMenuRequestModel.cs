namespace DataViewModels.Requests
{
    public class CreateMenuRequestModel
    {
        public string menuName { get; set; }
        public string menuDescription { get; set; }
        public int menuPrice { get; set; }
        public List<string> menuImages { get; set; } = new List<string>();
        public string menuType { get; set; }
    }
}
