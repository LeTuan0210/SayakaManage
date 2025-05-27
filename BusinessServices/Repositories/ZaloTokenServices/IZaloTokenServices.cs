namespace BusinessServices.Repositories
{
    public interface IZaloTokenServices
    {
        Task<string> GetAccessToken();
        Task<bool> CreateTokenAsync(string userId);
        Task<bool> DeteleTokenAsync(string userId);
        Task<bool> CheckTokenAsync(string userId);
    }
}
