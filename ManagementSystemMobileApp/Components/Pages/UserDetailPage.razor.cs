using BusinessServices.Repositories;
using DataViewModels.Requests;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ManagementSystemMobileApp.Components.Pages
{
    public partial class UserDetailPage
    {
        // Dependency Injection
        #region
        [Inject]
        protected NavigationManager navigation { get; set; } // Quản lý chuyển trang
        [Inject]
        protected IMemberClientServices _memberService { get; set; }
        [Inject]
        protected IJSRuntime js { get; set; }
        #endregion

        // Variable
        #region
        [SupplyParameterFromForm]
        UpdateMemberModel member { get; set; } = new();

        string failInfomation = "";

        #endregion

        // Function
        #region
        protected override async Task OnInitializedAsync() // Hàm Khởi tạo, Load Data
        {
            member = await _memberService.GetUpdateMemberModel();

            StateHasChanged();

            failInfomation = _memberService.IsCompleteInfomation();

            if (!string.IsNullOrEmpty(failInfomation))
               failInfomation = $"Thông tin cần cập nhật: {failInfomation}";
        }

        async Task SubmitForm()
        {
            var resultUpdate = await _memberService.UpdateMemberInfoByUser(member);
            if (resultUpdate != null) 
            {
                //await js.InvokeVoidAsync("ShowPageAlert", "Cập nhật thông tin thành công");
                navigation.NavigateTo(navigation.BaseUri);
            }
            else
            {
                //await js.InvokeVoidAsync("ShowPageAlert", "Cập nhật thông tin thất bại");
            }
        }
        #endregion
    }
}
