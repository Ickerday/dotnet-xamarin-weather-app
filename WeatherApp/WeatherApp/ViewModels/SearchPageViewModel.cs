using MvvmHelpers;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Shared.Exceptions;
using WeatherApp.Shared.Models;
using WeatherApp.Shared.Services;

namespace WeatherApp.Shared.ViewModels
{
    public class SearchPageListItem
    {
        public string Name { get; set; }

        public SearchPageListItem(string name = "") =>
            Name = name;
    }

    public class SearchPageViewModel : BaseViewModel
    {
        private readonly IRepository<Forecast> _forecastRepository;

        public ObservableCollection<SearchPageListItem> PreviousCities { get; set; }

        public SearchPageViewModel()
        {
            Title = "Find city";
            _forecastRepository = new ForecastRepository(App.Database);
            PreviousCities = new ObservableCollection<SearchPageListItem>();
        }

        public void AddToPreviousCities(string cityName)
        {
            if (string.IsNullOrEmpty(cityName) || PreviousCities.Any(c => c.Name.Contains(cityName)))
                return;

            PreviousCities.Add(new SearchPageListItem(cityName));
        }

        public async Task GetForecastHistoryAsync()
        {
            try
            {
                var history = await _forecastRepository.GetAsync();
                var listItems = history.Select(f => new SearchPageListItem($"{f.Name}, {f.Country}"));

                PreviousCities.Clear();
                foreach (var item in listItems)
                    PreviousCities.Add(item);
            }
            catch (Exception ex)
            {
                throw new AppException("Couldn't get forecast history.", ex);
            }
        }

        public async Task ClearForecastHistory()
        {
            try
            {
                await _forecastRepository.ClearAsync();
                PreviousCities.Clear();
            }
            catch (Exception ex)
            {
                throw new AppException("Couldn't clear history.", ex);
            }
        }
    }
}
