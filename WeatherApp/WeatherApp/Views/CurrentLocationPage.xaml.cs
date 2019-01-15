using System;
using System.Threading.Tasks;
using WeatherApp.ViewModels;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentLocationPage
    {
        private readonly CurrentLocationPageViewModel _viewModel;

        public CurrentLocationPage()
        {
            BindingContext = _viewModel = new CurrentLocationPageViewModel();
            InitializeComponent();
        }

        protected async void OnGetWeatherButtonClicked(object sender, EventArgs args)
        {
            try
            {
                await _viewModel.GetForecastForCurrentLocation();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        public async Task OnInputFromMasterPageAsync(string name)
        {
            try
            {
                await _viewModel.GetForecastForCityName(name);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        public void OnStart()
        {
            _viewModel.GetLastForecastFromDb()
                .ConfigureAwait(false);
        }
    }
}