using RestEase;
using System.Threading.Tasks;
using WeatherApp.Exceptions;
using WeatherApp.Models.Dto;
using Xamarin.Essentials;

namespace WeatherApp.Services
{
    public interface IWeatherService
    {
        [Path("apiKey")]
        string ApiKey { get; set; }

        [Get("weather?q={cityName}&appid={apiKey}")]
        Task<string> GetByCityNameAsync([Path("cityName")] string cityName);

        [Get("weather?q={id}&appId={apiKey}")]
        Task<string> GetByIdAsync([Path("id")] int id);

        [Get("weather?lat={latitude}&lon={longitude}&appId={apiKey}")]
        Task<ApiResult> GetByLocationAsync([Path("latitude")] float latitude, [Path("longitude")] float longitude);
    }

    public class WeatherApiService
    {
        private const string SampleKey = "b6907d289e10d714a6e88b30761fae22";
        private const string SampleUrl = "https://samples.openweathermap.org/data/2.5";

        private const string ApiKey = "2069213dc25f76d153d15c301f7f013c";
        private const string BaseUrl = "https://api.openweathermap.org/data/2.5";

        private readonly IWeatherService _client;

        public WeatherApiService()
        {
            _client = RestClient.For<IWeatherService>(BaseUrl);
            _client.ApiKey = ApiKey;
        }

        public async Task<string> GetByCityNameAsync(string name) => await _client
                .GetByCityNameAsync(name);

        public async Task<string> GetByIdAsync(int id) => await _client
            .GetByIdAsync(id);

        public async Task<ApiResult> GetByLocationAsync(Location location)
        {
            var result = await _client
                .GetByLocationAsync((float)location.Latitude, (float)location.Longitude);

            if (result.Cod == 200)
                return result;

            throw new AppException($"OpenWeatherAPI returned {result.Cod}: {result.Message}");
        }
    }
}
