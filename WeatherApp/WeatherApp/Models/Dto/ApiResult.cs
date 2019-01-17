using System.Collections.Generic;

namespace WeatherApp.Shared.Models.Dto
{
    public class ApiResult : EntityBase
    {
        public virtual Coord Coord { get; set; }
        public virtual IEnumerable<Weather> Weather { get; set; }
        public virtual string Base { get; set; }
        public virtual Atmosphere Main { get; set; }
        public virtual int Visibility { get; set; }
        public virtual Wind Wind { get; set; }
        public virtual Clouds Clouds { get; set; }
        public virtual double Dt { get; set; }
        public virtual Sys Sys { get; set; }
        public virtual string Name { get; set; }
        public virtual int Cod { get; set; }
        public virtual string Message { get; set; }
    }
}
