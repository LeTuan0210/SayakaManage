using AutoMapper;
using DataModels.Filter;
using DataServices.Interfaces;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public class MenuBaseServices(IMenuDataServices _menuService, IMapper _mapper) : IMenuBaseServices
    {
        public async Task<List<MenuResponseModel>> GetAllMenuAsync(MenuFilter filter)
        {
            try
            {
                var listMenu = await _menuService.GetAllMenuAsync(filter);
                var result = _mapper.Map<List<MenuResponseModel>>(listMenu);
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
