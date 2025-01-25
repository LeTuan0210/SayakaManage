using DataViewModels.Requests;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public interface IRestaurantAreaServerServices : IRestaurantAreaBaseServices
    {
        Task<RestaurantAreaResponseModel> CreateNewAreaAsync(CreateAreaRequestModel model);
        Task<UpdateAreaRequestModel> GetUpdateAreaAsync(Guid id);
        Task<RestaurantAreaResponseModel> UpdateAreaAsync(UpdateAreaRequestModel model);
        Task<bool> DeleteAreaAsync(Guid id);
    }
}
