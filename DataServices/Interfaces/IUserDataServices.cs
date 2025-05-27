namespace DataServices.Interfaces
{
    public interface IUserDataServices
    {
        Task<ApplicationUser> GetUserByUsername(string username);
    }
}
