using MvvmHelpers;
using System.Collections.ObjectModel;

namespace WeatherApp.ViewModels
{
    public class SearchPageListItem
    {
        public string Name { get; set; }

        public SearchPageListItem(string name = "") =>
            Name = name;
    }

    public class SearchPageViewModel : BaseViewModel
    {
        public ObservableCollection<SearchPageListItem> PreviousCities { get; set; }

        public SearchPageViewModel()
        {
            Title = "Find city";
            PreviousCities = new ObservableCollection<SearchPageListItem>
            {
                new SearchPageListItem("Kyoto, JP"),
                new SearchPageListItem("Seattle, US")
            };
        }

        public void AddToPreviousCities(string cityName)
        {
            if (string.IsNullOrEmpty(cityName))
                return;

            PreviousCities.Add(new SearchPageListItem(cityName));
        }
    }
}
