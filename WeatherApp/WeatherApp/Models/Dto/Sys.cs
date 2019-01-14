namespace WeatherApp.Models.Dto
{
    public class Sys : BaseEntity
    {
        public virtual int Type { get; set; }
        public virtual double Message { get; set; }
        public virtual string Country { get; set; }
        public virtual int Sunrise { get; set; }
        public virtual int Sunset { get; set; }
    }
}
