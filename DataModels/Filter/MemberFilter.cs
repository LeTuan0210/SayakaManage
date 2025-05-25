namespace DataModels.Filter
{
    public class MemberFilter : BaseFilter
    {
        public MemberFilter()
        {
            PageSize = 450;
        }
        public int birthdayMonth { get; set; } = 0;
        public int isSentPromotion { get; set; } = 0;
    }
}
