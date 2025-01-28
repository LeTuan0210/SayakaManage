using BusinessServices.Repositories;
using DataModels.Filter;
using DataViewModels.Responses;
using Microsoft.AspNetCore.Components;

namespace ManagementSystemMobileApp.Components.Pages
{
    public partial class RestaurantPage
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
        List<RestaurantResponseModel> restaurants { get; set; } // Danh sách Nhà hàng
        string selectedArea { get; set; } = "";
        string selectedCity { get; set; } = "";

        #endregion

        // Function
        #region
        protected override async Task OnInitializedAsync() // Hàm Khởi tạo, Load Data
        {
            restaurants = await _restaurantServices.GetAllRestaurantsAsync(new RestaurantFilter { PageSize = 100 });
        }
        #endregion
    }
}
