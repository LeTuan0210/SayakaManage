namespace DataViewModels.Requests
{
    public class SendPromotionRequestModel
    {
        public Recipient recipient { get; set; } = new Recipient();
        public ZaloPromotionMessage message { get; set; } = new ZaloPromotionMessage();
    }
}
