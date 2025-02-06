namespace BusinessServices.Repositories
{
    public interface IZaloTokenServices
    {
        Task<string> GetAccessToken();
    }
}
