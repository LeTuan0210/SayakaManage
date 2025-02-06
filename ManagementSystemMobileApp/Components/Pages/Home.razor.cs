using BusinessServices.Repositories;
using DataModels.Filter;
using DataViewModels.Requests;
using DataViewModels.Responses;
using Microsoft.AspNetCore.Components;

namespace ManagementSystemMobileApp.Components.Pages
{
    public partial class Home
    {
        // Dependency Injection
        #region
        [Inject]
        protected NavigationManager navigation {  get; set; } // Quản lý chuyển trang
        [Inject]
        protected ISystemPromotionClientServices _promotionServices { get; set; }
        [Inject]
        protected IRestaurantClientServices _restaurantServices { get; set; }
        [Inject]
        protected IMenuClientServices _menuServices { get; set; }
        [Inject]
        protected IMemberClientServices _memberServices { get; set; }
        #endregion

        // Variable
        #region
        List<SystemPromotionResponseModel> promotions { get; set; } // Danh sách khuyến mãi
        List<RestaurantResponseModel> restaurants { get; set; } // Danh sách Nhà hàng
        List<MenuResponseModel> menus { get; set; } // Danh sach Menu
        string selectedMenuCategory { get; set; } = "Buffet";

        MemberAppInfo? member;

        #endregion

        // Function
        #region
        protected override async Task OnInitializedAsync() // Hàm Khởi tạo, Load Data
        {
            promotions = await _promotionServices.GetAllPromotionAsync(new PromotionFilter());
            restaurants = await _restaurantServices.GetAllRestaurantsAsync(new RestaurantFilter { PageSize = 100});
            menus = await _menuServices.GetAllMenuAsync(new MenuFilter());
            member = await _memberServices.GetMemberInfo();
            StateHasChanged();
        }
        void ChangePage(string page)
        {
            navigation.NavigateTo(page);
        }
        #endregion
    }
}
