
namespace DataViewModels.Responses
{
    public class ZaloPromotionResponseModel
    {
        public Guid Id { get; set; }
        public bool isDefault { get; set; } = false;
        public bool isEnable { get; set; } = true;
        public DateTime createDate { get; set; } = DateTime.Now;
        public DateTime updateDate { get; set; } = DateTime.Now;
        public List<ZaloButtonResponseModel> buttons { get; set; }
        public List<ZaloElementResponseModel>? elements { get; set; }
        public override string ToString()
        {
            var header = elements.FirstOrDefault(x => x.type == "header");
            if (header != null)
            {
                return header.content;
            }
            return "Khuyến mãi chưa đặt tên";
        }
    }
    public class ZaloButtonResponseModel
    {
        public Guid Id { get; set; }
        public string title { get; set; }
        public string imageIcon { get; set; }
        public string type { get; set; }
        public string payload { get; set; }
    }
    public class ZaloElementResponseModel
    {
        public Guid Id { get; set; }
        public string type { get; set; }
        public string content { get; set; }
    }
}
