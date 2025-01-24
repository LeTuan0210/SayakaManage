namespace DataModels.Entities
{
    public class SystemPromotion
    {
        public Guid Id { get; set; }
        public string promotionName { get; set; }
        public string promotionAlias { get; set; }
        public string imageBannerLink { get; set; }
        public string promotionContent { get; set; }
        public DateTime createDate { get; set; } = DateTime.Now;
        public int promotionViewCount { get; set; } = 0;
        public int promotionLikeCount { get; set; } = 0;
    }
}
