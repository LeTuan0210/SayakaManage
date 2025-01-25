using AutoMapper;
using DataModels.Entities;
using DataServices.Interfaces;
using DataViewModels.Requests;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public class MenuServerServices : MenuBaseServices, IMenuServerServices
    {
        private readonly IMenuDataServices _menuService;
        private readonly IMapper _mapper;
        public MenuServerServices(IMenuDataServices menuService, IMapper mapper) : base(menuService, mapper)
        {
            _mapper = mapper;
            _menuService = menuService;
        }
        public async Task<MenuResponseModel> CreateNewMenuAsync(CreateMenuRequestModel model)
        {
            try
            {
                var createModel = _mapper.Map<RestaurantMenu>(model);

                createModel = await _menuService.CreateNewMenuAsync(createModel);

                return _mapper.Map<MenuResponseModel>(createModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        
        public async Task<MenuResponseModel> GetMenuByIdAsync(Guid id)
        {
            try
            {
                var result = await _menuService.GetMenuAsync(id);

                return _mapper.Map<MenuResponseModel>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<UpdateMenuRequestModel> GetUpdateMenuAsync(Guid id)
        {
            try
            {
                var result = await _menuService.GetMenuAsync(id);

                return _mapper.Map<UpdateMenuRequestModel>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<MenuResponseModel> UpdateMenuAsync(UpdateMenuRequestModel model)
        {
            try
            {
                var updateModel = await _menuService.GetMenuAsync(model.Id);

                if (updateModel == null)
                    return null;

                _mapper.Map(model, updateModel);

                updateModel = await _menuService.UpdateMenuAsync(updateModel);

                return _mapper.Map<MenuResponseModel>(updateModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<bool> DeleteMenuAsync(Guid id)
        {
            try
            {
                await _menuService.DeleteMenuAsync(id);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
