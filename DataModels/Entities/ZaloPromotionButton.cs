namespace DataModels.Entities
{
    public class ZaloPromotionButton
    {
        public Guid Id { get; set; }
        public string title { get; set; }
        public string imageIcon { get; set; }
        public string type { get; set; }
        public string payload { get; set; }
        public ZaloPromotion promotion { get; set; }
    }
}
