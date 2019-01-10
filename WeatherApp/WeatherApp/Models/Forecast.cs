using Xamarin.Essentials;

namespace WeatherApp.Models
{
    public class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public class Forecast : BaseEntity
    {
        public Location Location { get; set; }
        
    }
}
