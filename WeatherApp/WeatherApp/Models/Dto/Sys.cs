namespace WeatherApp.Shared.Models.Dto
{
    public class Sys : EntityBase
    {
        public virtual int Type { get; set; }
        public virtual double Message { get; set; }
        public virtual string Country { get; set; }
        public virtual int Sunrise { get; set; }
        public virtual int Sunset { get; set; }
    }
}
