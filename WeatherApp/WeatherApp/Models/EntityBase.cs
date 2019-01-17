using SQLite;

namespace WeatherApp.Shared.Models
{
    public class EntityBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}