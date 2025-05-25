namespace DataModels.Entities
{
    public class ZaloPromotion
    {
        public Guid Id { get; set; }
        public bool isDefault { get; set; } = false;
        public bool isEnable { get; set; } = true;
        public DateTime createDate { get; set; } = DateTime.Now;
        public DateTime updateDate { get; set; } = DateTime.Now;
        public DateTime lastSend { get; set; } = DateTime.Now;
        public List<ZaloPromotionElement> elements { get; set; }
        public List<ZaloPromotionButton>? buttons { get; set; }
    }
}
