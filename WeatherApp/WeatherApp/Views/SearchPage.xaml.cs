using System;
using WeatherApp.Shared.ViewModels;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Shared.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage
    {
        private readonly SearchPageViewModel _viewModel;

        public SearchPage()
        {
            BindingContext = _viewModel = new SearchPageViewModel();
            InitializeComponent();

            CityEntry.Completed += Search_OnCompleted;
            ClearHistoryButton.Clicked += ClearHistoryButton_OnClickedAsync;
        }

        public void OnStart()
        {
            _viewModel.GetForecastHistoryAsync()
                .ConfigureAwait(false);
        }

        private async void ClearHistoryButton_OnClickedAsync(object sender, EventArgs e)
        {
            var clearConfirmed = await DisplayAlert("Clear history",
                "Do you really want to clear your history?", "Yes", "No");

            if (clearConfirmed)
                await _viewModel.ClearForecastHistory();
        }

        private void Search_OnCompleted(object sender, EventArgs e)
        {
            var cityEntry = CityEntry.Text;
            if (string.IsNullOrEmpty(cityEntry))
                return;

            _viewModel.AddToPreviousCities(cityEntry);
        }
    }
}