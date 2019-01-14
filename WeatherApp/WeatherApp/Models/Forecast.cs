using System;

namespace WeatherApp.Models
{
    public class Forecast : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Country { get; set; }
        public virtual double Latitude { get; set; }
        public virtual double Longitude { get; set; }
        public virtual double Temperature { get; set; }
        public virtual string TemperatureUnit { get; set; }
        public virtual int Humidity { get; set; }
        public virtual DateTime CheckedAt { get; set; }
    }
}
