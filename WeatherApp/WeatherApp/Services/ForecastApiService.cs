using System;
using System.Threading.Tasks;
using RestEase;
using WeatherApp.Shared.Models.Dto;
using Xamarin.Essentials;

namespace WeatherApp.Shared.Services
{
    public interface IForecastApiService
    {
        [Path("apiKey")]
        string ApiKey { get; set; }

        [Get("weather?q={cityName}&units=metric&appid={apiKey}")]
        Task<ApiResult> GetForecastByCityNameAsync([Path("cityName")] string cityName);

        [Get("weather?lat={latitude}&lon={longitude}&units=metric&appId={apiKey}")]
        Task<ApiResult> GetForecastByLocationAsync([Path("latitude")] float latitude, [Path("longitude")] float longitude);
    }

    public class ForecastApiService
    {
        private const string ApiKey = "2069213dc25f76d153d15c301f7f013c";
        private const string BaseUrl = "https://api.openweathermap.org/data/2.5";
        private const string IconUrl = "https://openweathermap.org";

        private readonly IForecastApiService _client;

        public ForecastApiService()
        {
            _client = RestClient.For<IForecastApiService>(BaseUrl);
            _client.ApiKey = ApiKey;
        }

        public async Task<ApiResult> GetForecastByCityNameAsync(string name) =>
            await _client.GetForecastByCityNameAsync(name);

        public async Task<ApiResult> GetForecastByLocationAsync(Location location) =>
            await _client.GetForecastByLocationAsync((float)location.Latitude, (float)location.Longitude);

        public async Task<Uri> GetForecastIconFromCode(string code) =>
            await Task.FromResult(new Uri($"{IconUrl}/img/w/{code}.png"));
    }
}
