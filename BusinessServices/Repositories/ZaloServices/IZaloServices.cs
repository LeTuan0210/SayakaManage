namespace BusinessServices.Repositories
{
    public interface IZaloServices
    {
        Task<bool> SendTextToAdmin(string text);
        Task<bool> SendPromotionToMember(string user_id);
        Task<bool> SendAllPromotion();
    }
}
