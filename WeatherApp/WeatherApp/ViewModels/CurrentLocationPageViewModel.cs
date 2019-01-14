using MvvmHelpers;
using System;
using System.Threading;
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

        public virtual Forecast Forecast { get; set; }

        public CurrentLocationPageViewModel()
        {
            Title = "Current location";
            _weatherService = new WeatherApiService();
            _locationService = new LocationService();
            _forecastRepository = new ForecastRepository(App.Database);

//            GetWeatherForLocation().Wait();
        }

        public async Task GetWeatherForLocation()
        {
            var location = await _locationService.GetCurrentOrLastLocation(new CancellationToken());
            var weather = await _weatherService.GetByLocationAsync(location);
            var forecast = new Forecast
            {
                Name = weather.Name,
                Country = weather.Sys.Country,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                Humidity = weather.Main.Humidity,
                Temperature = weather.Main.Temp,
                TemperatureUnit = "Fahrenheit",
                CheckedAt = DateTime.Now
            };

            // TODO: BIND FORECAST TO TEXTCELLS
            Forecast = forecast;
            
            await _forecastRepository.SaveAsync(forecast);
        }
    }
}