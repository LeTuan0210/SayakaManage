namespace DataViewModels.Requests
{
    public class ZaloElementRequestModel
    {
        public string type { get; set; }
        public string attachment_id { get; set; }
        public string image_url { get; set; }
        public string content { get; set; }
        public string align { get; set; } = "left";
    }
}
