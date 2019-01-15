using MvvmHelpers;
using System;
using System.Threading.Tasks;
using WeatherApp.Exceptions;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
    public class CurrentLocationPageViewModel : BaseViewModel
    {
        private readonly WeatherApiService _weatherService;
        private readonly ILocationService _locationService;
        private readonly IRepository<Forecast> _forecastRepository;

        private string _name = string.Empty;
        public string Name { get => _name; set => SetProperty(ref _name, value); }

        private string _country = string.Empty;
        public string Country { get => _country; set => SetProperty(ref _country, value); }

        private string _temperatureString = string.Empty;
        public string TemperatureString { get => _temperatureString; set => SetProperty(ref _temperatureString, value); }

        private string _humidityString;
        public string HumidityString { get => _humidityString; set => SetProperty(ref _humidityString, value); }

        private double _latitude;
        public double Latitude { get => _latitude; set => SetProperty(ref _latitude, value); }

        private double _longitude;
        public double Longitude { get => _longitude; set => SetProperty(ref _longitude, value); }

        public CurrentLocationPageViewModel()
        {
            Title = "Current location";
            _weatherService = new WeatherApiService();
            _locationService = new LocationService();
            _forecastRepository = new ForecastRepository(App.Database);
        }

        public async Task GetForecastForCurrentLocation()
        {
            try
            {
                var location = await _locationService.GetCurrentOrLastLocation();
                var weather = await _weatherService.GetByLocationAsync(location);
                var forecast = Forecast.FromData(location, weather);

                await _forecastRepository.SaveAsync(forecast);
                SetProperties(forecast);
            }
            catch (Exception ex)
            {
                throw new AppException("Couldn't get forecast for your location.", ex);
            }
        }

        public async Task GetForecastForCityName(string name)
        {
            try
            {
                var weather = await _weatherService.GetByCityNameAsync(name);
                var forecast = Forecast.FromData(weather);

                await _forecastRepository.SaveAsync(forecast);
                SetProperties(forecast);
            }
            catch (Exception ex)
            {
                throw new AppException("Couldn't get forecast for your city.", ex);
            }
        }

        public async Task GetLastForecastFromDb()
        {
            try
            {
                var forecast = await _forecastRepository.GetLast();
                SetProperties(forecast);
            }
            catch (Exception ex)
            {
                throw new AppException("Couldn't get last known location.", ex);
            }
        }

        private void SetProperties(Forecast forecast)
        {
            Name = forecast.Name;
            Country = forecast.Country;
            TemperatureString = $"{forecast.Temperature}{forecast.TemperatureUnit}";
            HumidityString = $"{forecast.Humidity}{forecast.HumidityUnit}";
            Latitude = forecast.Latitude;
            Longitude = forecast.Longitude;
        }
    }
}