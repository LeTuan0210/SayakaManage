using DataModels.Filter;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public interface IMenuClientServices
    {
        Task<MenuResponseModel> GetMenuByAliasAsync(string alias);
        Task<List<MenuResponseModel>> GetRelatedMenuAsync(MenuFilter filter);
    }
}
