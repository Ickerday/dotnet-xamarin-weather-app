using System;
using WeatherApp.ViewModels;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage
    {
        private readonly SearchPageViewModel _viewModel;

        public SearchPage()
        {
            BindingContext = _viewModel = new SearchPageViewModel();
            InitializeComponent();

            CityEntry.Completed += OnSearchCompleted;
        }

        public void OnStart()
        {
            _viewModel.GetForecastHistoryAsync()
                .ConfigureAwait(false);
        }

        private void OnSearchCompleted(object sender, EventArgs e)
        {
            var cityEntry = CityEntry.Text;
            if (string.IsNullOrEmpty(cityEntry))
                return;

            _viewModel.AddToPreviousCities(cityEntry);
        }
    }
}