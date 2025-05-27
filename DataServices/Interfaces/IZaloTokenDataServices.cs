using DataModels.Entities;

namespace DataServices.Interfaces
{
    public interface IZaloTokenDataServices
    {
        public Task<List<ZaloToken>> GetAllToken();
        public Task<ZaloToken> GetTokenById(string id);
        public Task<ZaloToken> UpdateToken(ZaloToken token);
        public Task<ZaloToken> CreateToken(ZaloToken token);
        public Task<bool> DeleteToken(string id);
    }
}
