using DataViewModels.Requests;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public interface IMenuServerServices
    {
        Task<MenuResponseModel> CreateNewMenuAsync(CreateMenuRequestModel model);
        Task<MenuResponseModel> GetMenuByIdAsync(Guid id);
        Task<UpdateMenuRequestModel> GetUpdateMenuAsync(Guid id);
        Task<MenuResponseModel> UpdateMenuAsync(UpdateMenuRequestModel model);
        Task<bool> DeleteMenuAsync(Guid id);
    }
}
