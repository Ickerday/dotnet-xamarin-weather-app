namespace WeatherApp.Models.Dto
{
    public class Atmosphere
    {
        public virtual double Temp { get; set; }
        public virtual float Pressure { get; set; }
        public virtual int Humidity { get; set; }
        public virtual double TempMin { get; set; }
        public virtual double TempMax { get; set; }
    }
}
