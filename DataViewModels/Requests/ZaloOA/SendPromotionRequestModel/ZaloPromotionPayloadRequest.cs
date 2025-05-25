namespace DataViewModels.Requests
{
    public class ZaloPromotionPayloadRequest
    {
        public string template_type { get; set; } = "promotion";
        public List<ZaloElementRequestModel> elements { get; set; } = new List<ZaloElementRequestModel>();
        public List<ZaloButtonRequestModel> buttons { get; set; } = new List<ZaloButtonRequestModel>();
    }
}
