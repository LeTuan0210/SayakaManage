using BusinessServices.Repositories;
using DataModels.Filter;
using DataViewModels.Responses;
using Microsoft.AspNetCore.Components;

namespace ManagementSystemMobileApp.Components.Pages
{
    public partial class MemberPoints
    {
        // Dependency Injection
        #region
        [Inject]
        protected NavigationManager navigation { get; set; } // Quản lý chuyển trang
        [Inject]
        protected ITransactionClientServices _transactionServices { get; set; }
        [Inject]
        protected IMemberClientServices _memberServices { get; set; }
        #endregion

        // Variable
        #region
        List<TransactionResponeModel> transactions { get; set; } = new List<TransactionResponeModel>(); // Danh sach Giao dich

        MemberResponseModel? member;

        string qrcode = "https://barcode.tec-it.com/barcode.ashx?data=memberid&code=Code128&translate-esc=on";

        #endregion

        // Function
        #region
        protected override async Task OnInitializedAsync() // Hàm Khởi tạo, Load Data
        {
            member = await _memberServices.GetMemberInfo();                       

            StateHasChanged();
        }
        protected override async Task OnParametersSetAsync()
        {
            if (member != null)
            {
                qrcode = $"https://barcode.tec-it.com/barcode.ashx?data={member.user_Id}&code=Code128&translate-esc=on";
                transactions = await _transactionServices.GetTransactionsAsync(new TransactionFilter { memberId = member.user_Id });
            }
            StateHasChanged();
        }
        #endregion
    }
}
