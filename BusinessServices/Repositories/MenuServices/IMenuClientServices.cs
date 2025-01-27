using DataModels.Filter;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public interface IMenuClientServices : IMenuBaseServices
    {
        Task<MenuResponseModel> GetMenuByAliasAsync(string alias);
        Task<List<MenuResponseModel>> GetRelatedMenuAsync(MenuFilter filter);
    }
}
