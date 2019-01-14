using System;
using WeatherApp.Exceptions;
using WeatherApp.Models.Dto;
using Xamarin.Essentials;

namespace WeatherApp.Models
{
    public class Forecast : BaseEntity
    {
        public virtual string Name { get; set; } = string.Empty;
        public virtual string Country { get; set; } = string.Empty;
        public virtual double Latitude { get; set; }
        public virtual double Longitude { get; set; }
        public virtual double Temperature { get; set; }
        public virtual string TemperatureUnit { get; set; } = "Fahrenheit";
        public virtual int Humidity { get; set; }
        public virtual DateTime CheckedAt { get; set; } = DateTime.Now;

        public static Forecast FromData(Location location, ApiResult weather)
        {
            if (location != null && weather != null)
                return new Forecast
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
            throw new AppException("Cannot create instance of Forecast. Some of the parameters are null.");
        }
    }
}
