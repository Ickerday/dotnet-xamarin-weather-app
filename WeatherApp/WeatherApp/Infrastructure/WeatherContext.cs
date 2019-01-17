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

        private void Seed()
        {
            var seed = new[]
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
                },
                new Forecast
                {
                    Name = "Berlin",
                    Country = "DE",
                    CheckedAt = DateTime.Now,
                    Temperature = 30,
                    Humidity = 100,
                    Latitude = 10,
                    Longitude = -100
                }
            };
            InsertAllAsync(seed);
        }
    }
}