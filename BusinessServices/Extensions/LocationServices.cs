using Microsoft.JSInterop;

namespace BusinessServices.Extensions
{
    public class LocationServices
    {
        private readonly IJSRuntime _jsRuntime;

        public LocationServices(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task GetLocation()
        {
            await _jsRuntime.InvokeVoidAsync("getGeoLocation");
        }

        [JSInvokable]
        public static void ReceiveGeoLocation(double latitude, double longitude)
        {
            Console.WriteLine($"Latitude: {latitude}, Longitude: {longitude}");
            // Xử lý vị trí người dùng ở đây
        }
    }
}
