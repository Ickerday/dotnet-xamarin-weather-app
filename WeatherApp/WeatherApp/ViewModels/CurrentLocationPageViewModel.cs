using MvvmHelpers;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
    public class CurrentLocationPageViewModel : BaseViewModel
    {
        private readonly WeatherApiService _weatherService;
        private readonly ILocationService _locationService;
        private readonly IRepository<int, Forecast> _forecastRepository;

        private string _name = string.Empty;
        public string Name { get => _name; set => SetProperty(ref _name, value); }

        private string _country = string.Empty;
        public string Country { get => _country; set => SetProperty(ref _country, value); }

        private double _latitude;
        public double Latitude { get => _latitude; set => SetProperty(ref _latitude, value); }

        private double _longitude;
        public double Longitude { get => _longitude; set => SetProperty(ref _longitude, value); }

        private string _temperatureString = string.Empty;
        public string TemperatureString { get => _temperatureString; set => SetProperty(ref _temperatureString, value); }

        private int _humidity;
        public int Humidity { get => _humidity; set => SetProperty(ref _humidity, value); }

        public CurrentLocationPageViewModel()
        {
            Title = "Current location";
            _weatherService = new WeatherApiService();
            _locationService = new LocationService();
            _forecastRepository = new ForecastRepository(App.Database);
        }

        public async Task GetForecastForCurrentLocation()
        {
            var location = await _locationService.GetCurrentOrLastLocation();
            var weather = await _weatherService.GetByLocationAsync(location);
            var forecast = Forecast.FromData(location, weather);

            await _forecastRepository.SaveAsync(forecast);
            SetProperties(forecast);
        }

        private void SetProperties(Forecast forecast)
        {
            Name = forecast.Name;
            Country = forecast.Country;
            Latitude = forecast.Latitude;
            Longitude = forecast.Longitude;
            TemperatureString = $"{forecast.Temperature} {forecast.TemperatureUnit}";
            Humidity = forecast.Humidity;
        }
    }
}