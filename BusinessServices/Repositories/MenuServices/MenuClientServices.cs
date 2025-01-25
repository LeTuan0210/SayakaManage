using AutoMapper;
using DataModels.Filter;
using DataServices.Interfaces;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public class MenuClientServices : MenuBaseServices, IMenuClientServices
    {
        private readonly IMenuDataServices _menuService;
        private readonly IMapper _mapper;
        public MenuClientServices(IMenuDataServices menuService, IMapper mapper) : base(menuService, mapper)
        {
            _mapper = mapper;
            _menuService = menuService;
        }

        public async Task<MenuResponseModel> GetMenuByAliasAsync(string alias)
        {
            try
            {
                var result = await _menuService.GetMenuAsync(alias);

                return _mapper.Map<MenuResponseModel>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<MenuResponseModel>> GetRelatedMenuAsync(MenuFilter filter)
        {
            try
            {
                var listMenu = await GetAllMenuAsync(filter);
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
