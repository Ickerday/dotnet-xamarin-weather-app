using SQLite;

namespace WeatherApp.Models
{
    public class EntityBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}