using RestEase;
using System.Threading.Tasks;
using WeatherApp.Models.Dto;
using Xamarin.Essentials;

namespace WeatherApp.Services
{
    public interface IWeatherService
    {
        [Path("apiKey")]
        string ApiKey { get; set; }

        [Get("weather?q={cityName}&units=metric&appid={apiKey}")]
        Task<ApiResult> GetByCityNameAsync([Path("cityName")] string cityName);

        [Get("weather?q={id}&units=metric&appId={apiKey}")]
        Task<ApiResult> GetByIdAsync([Path("id")] int id);

        [Get("weather?lat={latitude}&lon={longitude}&units=metric&appId={apiKey}")]
        Task<ApiResult> GetByLocationAsync([Path("latitude")] float latitude, [Path("longitude")] float longitude);
    }

    public class WeatherApiService
    {
        private const string ApiKey = "2069213dc25f76d153d15c301f7f013c";
        private const string BaseUrl = "https://api.openweathermap.org/data/2.5";

        private readonly IWeatherService _client;

        public WeatherApiService()
        {
            _client = RestClient.For<IWeatherService>(BaseUrl);
            _client.ApiKey = ApiKey;
        }

        public async Task<ApiResult> GetByCityNameAsync(string name) =>
            await _client.GetByCityNameAsync(name);

        public async Task<ApiResult> GetByIdAsync(int id) =>
            await _client.GetByIdAsync(id);

        public async Task<ApiResult> GetByLocationAsync(Location location) =>
            await _client.GetByLocationAsync((float)location.Latitude, (float)location.Longitude);
    }
}
