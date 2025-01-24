namespace DataViewModels.Requests.SystemPromotion
{
    public class UpdateSystemPromotionRequestModel
    {
        public Guid Id { get; set; }
        public string promotionName { get; set; }
        public string promotionAlias { get; set; }
        public string imageBannerLink { get; set; }
        public string promotionContent { get; set; }
        public int promotionViewCount { get; set; } = 0;
        public int promotionLikeCount { get; set; } = 0;
    }
}
