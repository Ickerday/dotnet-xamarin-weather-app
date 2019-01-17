using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Shared.Infrastructure;
using WeatherApp.Shared.Models;

namespace WeatherApp.Shared.Services
{
    public interface IRepository<TValue>
    {
        Task<IEnumerable<TValue>> GetAsync();
        Task<TValue> GetLast();
        Task<int> SaveAsync(TValue item);
        Task<int> ClearAsync();
    }

    public class ForecastRepository : IRepository<Forecast>
    {
        private readonly WeatherContext _database;

        public ForecastRepository(WeatherContext database) =>
            _database = database;

        public async Task<IEnumerable<Forecast>> GetAsync() => await _database.Table<Forecast>()
            .ToArrayAsync();

        public async Task<Forecast> GetLast() => await _database.Table<Forecast>()
                .OrderByDescending(x => x.CheckedAt)
                .FirstOrDefaultAsync();

        public async Task<int> SaveAsync(Forecast item) => await _database.FindAsync<Forecast>(item.Id) != null
            ? await _database.UpdateAsync(item)
            : await _database.InsertAsync(item);

        public async Task<int> ClearAsync() => await _database.DeleteAllAsync<Forecast>();
    }
}