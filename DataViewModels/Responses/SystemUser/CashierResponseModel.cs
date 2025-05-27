namespace DataViewModels.Responses
{
    public class CashierResponseModel : SystemUserResponseModel
    {
        public CashierResponseModel()
        {
            position = "Cashier";
        }
        public string restaurantId { get; set; }
        public string restaurantName { get; set; }
    }
}
