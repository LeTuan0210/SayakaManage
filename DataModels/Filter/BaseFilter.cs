namespace DataModels.Filter
{
    public class BaseFilter
    {
        public string FilterName { get; set; } = string.Empty;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int skipItem { get => PageNumber > 0 ? (PageNumber - 1) * PageSize : 0; } // Item se bo qua khi loc
        public int SortByName { get; set; } = 1;     
        public Guid ExceptItem {  get; set; }
    }
}