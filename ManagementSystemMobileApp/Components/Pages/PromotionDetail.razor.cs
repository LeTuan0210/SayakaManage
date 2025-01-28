using BusinessServices.Repositories;
using DataModels.Filter;
using DataViewModels.Responses;
using Microsoft.AspNetCore.Components;

namespace ManagementSystemMobileApp.Components.Pages
{
    public partial class PromotionDetail
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
        [Parameter]
        public string promotionAlias { get; set; } = "";
        List<SystemPromotionResponseModel> promotions { get; set; } // Danh sách khuyến mãi

        SystemPromotionResponseModel promotion { get; set; }
        #endregion

        // Function
        #region
        protected override async Task OnInitializedAsync() // Hàm Khởi tạo, Load Data
        {
            
        }
        protected override async Task OnParametersSetAsync()
        {
            promotion = await _promotionServices.GetPromotionByAliasAsync(promotionAlias);
            promotions = await _promotionServices.GetAllPromotionAsync(new PromotionFilter { ExceptItem = promotion.Id});
        }
        #endregion
    }
}
