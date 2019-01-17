using SQLite;
using System;
using WeatherApp.Shared.Models;

namespace WeatherApp.Shared.Infrastructure
{
    public class WeatherContext : SQLiteAsyncConnection
    {
        public WeatherContext(string dbPath) : base(dbPath)
        {
            CreateTableAsync<Forecast>().Wait();

            if (Table<Forecast>().CountAsync().Result == 0)
                Seed();
        }

        private void Seed() => InsertAllAsync(new[]
        {
            new Forecast
            {
                Name = "Kraków",
                Country = "PL",
                CheckedAt = DateTime.Now + TimeSpan.FromHours(1),
                Temperature = 10,
                Humidity = 10,
                Latitude = 100,
                Longitude = 100,
            }
        });
    }
}
