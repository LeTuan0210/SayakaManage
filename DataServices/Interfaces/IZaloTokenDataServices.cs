using DataModels.Entities;

namespace DataServices.Interfaces
{
    public interface IZaloTokenDataServices
    {
        public Task<List<ZaloToken>> GetAllToken();
        public Task<ZaloToken> GetTokenById(string id);
        public Task<ZaloToken> UpdateToken(ZaloToken token);
    }
}
