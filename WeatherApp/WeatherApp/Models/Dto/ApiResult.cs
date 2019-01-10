using System.Collections.Generic;

namespace WeatherApp.Models.Dto
{
    public class ApiResult
    {
        public int Id { get; set; }
        public Coord Coord { get; set; }
        public IEnumerable<Weather> Weather { get; set; }
        public string Base { get; set; }
        public Atmosphere Atmosphere { get; set; }
        public int Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public int Dt { get; set; }
        public Sys Sys { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }
}
