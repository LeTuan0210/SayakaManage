using BusinessServices.Repositories.SystemPromotionServices;
using DataViewModels.Responses.Restaurant;
using DataViewModels.Responses.RestaurantMenu;
using DataViewModels.Responses.SystemPromotion;
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
        #endregion

        // Variable
        #region
        List<SystemPromotionResponseModel> promotions { get; set; } // Danh sách khuyến mãi
        List<RestaurantResponseModel> restaurants { get; set; } // Danh sách Nhà hàng
        List<MenuResponseModel> menus { get; set; } // Danh sach Menu
        #endregion

        // Function
        #region
        void ChangePage(string page)
        {
            navigation.NavigateTo(page);
        }
        #endregion
    }
}
