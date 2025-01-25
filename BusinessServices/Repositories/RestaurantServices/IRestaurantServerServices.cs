using DataViewModels.Requests.RestaurantInfo;
using DataViewModels.Responses.Restaurant;

namespace BusinessServices.Repositories.RestaurantServices
{
    internal interface IRestaurantServerServices : IRestaurantBaseServices
    {
        Task<RestaurantResponseModel> CreateNewRestaurantAsync(CreateRestaurantRequestModel model);
        Task<RestaurantResponseModel> GetRestaurantByIdAsync(Guid id);
        Task<UpdateRestaurantRequestModel> GetUpdateRestaurantAsync(Guid id);
        Task<RestaurantResponseModel> UpdateRestaurantAsync(UpdateRestaurantRequestModel model);
        Task<bool> DeleteRestaurantAsync(Guid id);
    }
}
