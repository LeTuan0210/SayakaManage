using Microsoft.JSInterop;

namespace BusinessServices.Extensions
{
    public class LocationServices
    {
        private readonly IJSRuntime _jsRuntime;
        private static double _latitude { get; set; } = 10.8382563;
        private static double _longitude { get; set; } = 106.6690751;

        private const double EarthRadiusKm = 6371;

        public LocationServices(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task GetLocation()
        {
            await _jsRuntime.InvokeVoidAsync("getGeoLocation");
        }

        public bool IsLocated() => _longitude != 106.6690751;


        public double CalculateDistance(double latitude, double longitude)
        {
            double dLat = DegreesToRadians(latitude - _latitude);

            double dLon = DegreesToRadians(longitude - _longitude);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                   Math.Cos(DegreesToRadians(latitude)) * Math.Cos(DegreesToRadians(_latitude)) *
                   Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return EarthRadiusKm * c;
        }
        private double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }

        [JSInvokable]
        public static void ReceiveGeoLocation(double latitude, double longitude)
        {
            Console.WriteLine($"Latitude: {latitude}, Longitude: {longitude}");
            _latitude = latitude;
            _longitude = longitude;
        }
    }
}
