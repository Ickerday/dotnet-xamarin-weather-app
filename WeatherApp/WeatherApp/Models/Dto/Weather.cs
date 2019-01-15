namespace WeatherApp.Models.Dto
{
    public class Weather : EntityBase
    {
        public virtual string Main { get; set; }
        public virtual string Description { get; set; }
        public virtual string Icon { get; set; }
    }
}
