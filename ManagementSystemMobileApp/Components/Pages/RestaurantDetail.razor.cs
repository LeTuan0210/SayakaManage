using BusinessServices.Repositories;
using DataModels.Filter;
using DataViewModels.Responses;
using Microsoft.AspNetCore.Components;

namespace ManagementSystemMobileApp.Components.Pages
{
    public partial class RestaurantDetail
    {
        // Dependency Injection
        #region
        [Inject]
        protected NavigationManager navigation { get; set; } // Quản lý chuyển trang
        [Inject]
        protected IRestaurantClientServices _restaurantServices { get; set; }
        #endregion

        // Variable
        #region

        [Parameter]
        public string restaurantAlias { get; set; } = "";
        RestaurantResponseModel restaurant {  get; set; }
        List<RestaurantResponseModel> restaurants { get; set; } // Danh sách Nhà hàng
        string selectedArea { get; set; } = "";
        string selectedCity { get; set; } = "";

        #endregion

        // Function
        #region
        protected override async Task OnParametersSetAsync()
        {
            restaurant = await _restaurantServices.GetRestaurantByAliasAsync(restaurantAlias);

            if (restaurant == null)
                navigation.NavigateTo(navigation.BaseUri);

            restaurants = await _restaurantServices.GetAllRestaurantsAsync(new RestaurantFilter { PageSize = 100, ExceptItem = restaurant.Id });
        }
        #endregion
    }
}
