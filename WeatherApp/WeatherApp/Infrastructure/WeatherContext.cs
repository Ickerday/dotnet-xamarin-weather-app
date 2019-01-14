using SQLite;
using WeatherApp.Models;

namespace WeatherApp.Infrastructure
{
    public class WeatherContext : SQLiteAsyncConnection
    {
        public WeatherContext(string dbPath) : base(dbPath)
        {
            CreateTableAsync<Forecast>().Wait();
        }
    }
}
