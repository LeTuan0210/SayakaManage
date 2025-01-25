using DataViewModels.Requests;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public interface IRestaurantServerServices : IRestaurantBaseServices
    {
        Task<RestaurantResponseModel> CreateNewRestaurantAsync(CreateRestaurantRequestModel model);
        Task<RestaurantResponseModel> GetRestaurantByIdAsync(Guid id);
        Task<UpdateRestaurantRequestModel> GetUpdateRestaurantAsync(Guid id);
        Task<RestaurantResponseModel> UpdateRestaurantAsync(UpdateRestaurantRequestModel model);
        Task<bool> DeleteRestaurantAsync(Guid id);
    }
}
