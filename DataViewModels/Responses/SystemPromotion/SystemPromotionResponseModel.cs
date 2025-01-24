namespace DataViewModels.Responses.SystemPromotion
{
    public class SystemPromotionResponseModel
    {
        public Guid Id { get; set; }
        public string promotionName { get; set; }
        public string promotionAlias { get; set; }
        public string imageBannerLink { get; set; }
        public string promotionContent { get; set; }
        public DateTime createDate { get; set; }
        public int promotionViewCount { get; set; }
        public int promotionLikeCount { get; set; }
    }
}
