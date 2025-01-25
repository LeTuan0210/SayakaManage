using AutoMapper;
using DataModels.Filter;
using DataServices.Interfaces;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public class RestaurantAreaBaseServices(IRestaurantAreaDataServices _areaService, IMapper _mapper) : IRestaurantAreaBaseServices
    {
        public async Task<List<RestaurantAreaResponseModel>> GetAllAreasAsync(AreaFilter filter)
        {
            try
            {
                var listMenu = await _areaService.GetAllAreaAsync(filter);
                var result = _mapper.Map<List<RestaurantAreaResponseModel>>(listMenu);
                return result;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
