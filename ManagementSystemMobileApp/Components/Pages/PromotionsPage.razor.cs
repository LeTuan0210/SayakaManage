using BusinessServices.Repositories;
using DataModels.Filter;
using DataViewModels.Responses;
using Microsoft.AspNetCore.Components;

namespace ManagementSystemMobileApp.Components.Pages
{
    public partial class PromotionsPage
    {
        // Dependency Injection
        #region
        [Inject]
        protected NavigationManager navigation { get; set; } // Quản lý chuyển trang
        [Inject]
        protected ISystemPromotionClientServices _promotionServices { get; set; }
        #endregion

        // Variable
        #region
        List<SystemPromotionResponseModel> promotions { get; set; } // Danh sách khuyến mãi

        #endregion

        // Function
        #region
        protected override async Task OnInitializedAsync() // Hàm Khởi tạo, Load Data
        {
            promotions = await _promotionServices.GetAllPromotionAsync(new PromotionFilter());
        }
        void ChangePage(string page)
        {
            navigation.NavigateTo(page);
        }
        #endregion
    }
}
