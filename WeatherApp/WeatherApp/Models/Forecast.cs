using SQLite;
using System;
using WeatherApp.Exceptions;
using WeatherApp.Models.Dto;
using Xamarin.Essentials;

namespace WeatherApp.Models
{
    public class Forecast : EntityBase
    {
        [MaxLength(100)]
        public virtual string Name { get; set; } = string.Empty;

        [MaxLength(5)]
        public virtual string Country { get; set; } = string.Empty;

        public virtual double Latitude { get; set; }

        public virtual double Longitude { get; set; }

        public virtual string TemperatureUnit { get; set; } = "°C";
        public virtual double Temperature { get; set; }

        public virtual string HumidityUnit { get; set; } = "%";
        public virtual int Humidity { get; set; }

        public virtual DateTime CheckedAt { get; set; } = DateTime.Now;

        public static Forecast FromData(ApiResult weather) => weather != null
            ? new Forecast
            {
                Name = weather.Name,
                Country = weather.Sys.Country,
                Humidity = weather.Main.Humidity,
                Temperature = weather.Main.Temp,
                Latitude = weather.Coord.Lat,
                Longitude = weather.Coord.Lon
            }
            : throw new AppException("Cannot create instance of Forecast. Some of the data is null.");

        public static Forecast FromData(Location location, ApiResult weather) => location != null && weather != null
            ? new Forecast
            {
                Name = weather.Name,
                Country = weather.Sys.Country,
                Humidity = weather.Main.Humidity,
                Temperature = weather.Main.Temp,
                Latitude = location.Latitude,
                Longitude = location.Longitude
            }
            : throw new AppException("Cannot create instance of Forecast. Some of the data is null.");
    }
}
