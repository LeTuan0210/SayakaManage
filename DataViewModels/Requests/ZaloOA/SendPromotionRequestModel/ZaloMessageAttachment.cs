namespace DataViewModels.Requests
{
    public class ZaloMessageAttachment
    {
        public string type { get; set; } = "template";
        public ZaloPromotionPayloadRequest payload { get; set; } = new ZaloPromotionPayloadRequest();
    }
}
