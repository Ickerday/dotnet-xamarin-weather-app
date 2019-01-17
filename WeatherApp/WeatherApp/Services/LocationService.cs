using System;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.Shared.Exceptions;
using Xamarin.Essentials;

namespace WeatherApp.Shared.Services
{
    public interface ILocationService
    {
        Task<Location> GetCurrentOrLastLocation();
    }

    public class LocationService : ILocationService
    {
        private const string CallToSearchAction = "Use the Search tab to find your location manually";

        public TimeSpan Timeout { get; set; } = new TimeSpan(0, 0, 3);

        public async Task<Location> GetCurrentOrLastLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, Timeout);
                return await Geolocation.GetLocationAsync(request, CancellationToken.None)
                       ?? await Geolocation.GetLastKnownLocationAsync();
            }
            catch (FeatureNotSupportedException ex)
            {
                throw new AppException($"Your phone does not support location services. {CallToSearchAction}", ex);
            }
            catch (PermissionException ex)
            {
                throw new AppException($"Missing permissions to use location services. {CallToSearchAction}", ex);
            }
            catch (Exception ex)
            {
                throw new AppException($"Unknown error happened. Sorry! {CallToSearchAction}", ex);
            }
        }
    }
}