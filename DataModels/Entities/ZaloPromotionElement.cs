namespace DataModels.Entities
{
    public class ZaloPromotionElement
    {
        public Guid Id { get; set; }
        public string type { get; set; }
        public string content { get; set; }
        public ZaloPromotion promotion { get; set; }
    }
}
