using SQLite;
using WeatherApp.Models;
using Xamarin.Essentials;

namespace WeatherApp.Infrastructure
{
    public class WeatherContext : SQLiteAsyncConnection
    {
        public WeatherContext(string dbPath) : base(dbPath)
        {
            CreateTableAsync<Location>().Wait();
            CreateTableAsync<Forecast>().Wait();
        }
    }
}
