using DataModels.Filter;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public interface IMenuBaseServices
    {
        Task<List<MenuResponseModel>> GetAllMenuAsync(MenuFilter filter);
    }
}
