using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Infrastructure;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class ForecastRepository : IRepository<int, Forecast>
    {
        private readonly WeatherContext _database;

        public ForecastRepository(WeatherContext database)
        {
            _database = database;
        }

        public async Task<IEnumerable<Forecast>> GetAsync() => await _database.Table<Forecast>()
            .ToArrayAsync();

        public async Task<Forecast> GetAsync(int id) => await _database.Table<Forecast>()
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<int> SaveAsync(Forecast item) => await _database.FindAsync<Forecast>(item.Id) != null
            ? await _database.UpdateAsync(item)
            : await _database.InsertAsync(item);

        public async Task<int> DeleteAsync(int id) =>
            await _database.DeleteAsync<Forecast>(id);

    }
}