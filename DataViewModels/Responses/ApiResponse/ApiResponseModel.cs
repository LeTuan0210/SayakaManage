namespace DataViewModels.Responses
{
    public class ApiResponseModel
    {
        public ApiResponseModel(string status, string message, object data = null)
        {
            this.data = data;
            this.status = status;
            this.message = message;
        }
        public string status {  get; set; }
        public string message { get; set; }
        public object? data { get; set; }
    }
}
