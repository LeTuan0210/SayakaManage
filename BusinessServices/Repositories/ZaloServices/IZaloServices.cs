namespace BusinessServices.Repositories
{
    public interface IZaloServices
    {
        Task<bool> SendTextToAdmin(string text);
    }
}
