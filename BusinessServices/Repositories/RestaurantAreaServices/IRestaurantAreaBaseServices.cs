using DataModels.Filter;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public interface IRestaurantAreaBaseServices
    {
        Task<List<RestaurantAreaResponseModel>> GetAllAreasAsync(AreaFilter filter);
    }
}
