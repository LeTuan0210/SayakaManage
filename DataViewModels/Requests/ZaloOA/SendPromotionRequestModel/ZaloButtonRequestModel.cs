namespace DataViewModels.Requests
{
    public class ZaloButtonRequestModel
    {
        public string title { get; set; }
        public string image_icon { get; set; }
        public string type { get; set; } = "oa.open.url";
        public ZaloButtonPayload payload { get; set; } = new ZaloButtonPayload();
    }
}
