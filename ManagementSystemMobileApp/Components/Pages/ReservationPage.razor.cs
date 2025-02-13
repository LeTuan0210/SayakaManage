using BusinessServices.Repositories;
using DataModels.Filter;
using DataViewModels.Requests;
using DataViewModels.Responses;
using Microsoft.AspNetCore.Components;

namespace ManagementSystemMobileApp.Components.Pages
{
    public partial class ReservationPage
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
        List<RestaurantResponseModel> restaurants { get; set; } // Danh sách Nhà hàng

        [SupplyParameterFromForm]
        CreateReservationModel model { get; set; } = new();
        string selectedArea { get; set; } = "";
        string selectedCity { get; set; } = "";

        int selectedHour { get; set; } = DateTime.Now.Hour > 10 ? DateTime.Now.Hour + 1 : 10;

        #endregion

        // Function
        #region
        protected override async Task OnInitializedAsync() // Hàm Khởi tạo, Load Data
        {
            restaurants = await _restaurantServices.GetAllRestaurantsAsync(new RestaurantFilter { PageSize = 100 });

            var reservationInfo = await _reservationServices.GetCustomerInfoReservation();

            if (reservationInfo != null)
            {
                model = reservationInfo;
                StateHasChanged();
            }
        } 
        async Task SubmitOrder()
        {
            model.orderDate = new DateTime(
                                            model.orderDate.Year,
                                            model.orderDate.Month,
                                            model.orderDate.Day,
                                            selectedHour,
                                            0,
                                            0);
            var order = await _reservationServices.CreateNewReservation(model);

            if(order != null)
            {
                navigation.NavigateTo($"/order/{order.id}");
            }
        }
        #endregion
    }
}
