using BusinessServices.Repositories;
using DataModels.Filter;
using DataViewModels.Requests;
using DataViewModels.Responses;
using Microsoft.AspNetCore.Components;

namespace ManagementSystemMobileApp.Components.Pages
{
    public partial class OrderInfomationPage
    {
        // Dependency Injection
        #region
        [Inject]
        protected NavigationManager navigation { get; set; } // Quản lý chuyển trang
        [Inject]
        protected IRestaurantClientServices _restaurantServices { get; set; }
        [Inject]
        protected IReservationClientServices _reservationServices { get; set; }
        #endregion

        // Variable
        #region
        [Parameter]
        public string id { get; set; }
        ReservationResponseModel model { get; set; }

        #endregion

        // Function
        #region
        protected override async Task OnInitializedAsync() // Hàm Khởi tạo, Load Data
        {
            var reservationInfo = await _reservationServices.GetReservationById(Guid.Parse(id));

            if (reservationInfo != null)
            {
                model = reservationInfo;
                StateHasChanged();
            }
        }
        async Task SubmitOrder()
        {
            
        }
        #endregion
    }
}
