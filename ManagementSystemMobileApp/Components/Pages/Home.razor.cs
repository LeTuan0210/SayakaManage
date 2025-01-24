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
        #endregion

        // Variable
        #region
        List<SystemPromotionResponseModel> promotions { get; set; } // Danh sách khuyến mãi
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
