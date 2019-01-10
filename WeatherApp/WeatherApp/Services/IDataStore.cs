using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherApp.Services
{
    public interface IDataStore<in TKey, TValue>
    {
        Task<IEnumerable<TValue>> GetAsync();
        Task<TValue> GetAsync(TKey id);
        Task<int> SaveAsync(TValue item);
        Task<int> DeleteAsync(TKey id);
    }
}
