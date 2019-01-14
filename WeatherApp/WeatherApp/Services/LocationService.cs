using System;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.Exceptions;
using Xamarin.Essentials;

namespace WeatherApp.Services
{
    public interface ILocationService
    {
        Task<Location> GetCurrentOrLastLocation(CancellationToken cancellationToken);
    }

    public class LocationService : ILocationService
    {
        private const string CallToSearchAction = "Use the Search tab to find your location manually";
        public TimeSpan Timeout = new TimeSpan(0, 0, 3);

        public async Task<Location> GetCurrentOrLastLocation(CancellationToken cancellationToken)
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, Timeout);
                return await Geolocation.GetLocationAsync(request, cancellationToken)
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