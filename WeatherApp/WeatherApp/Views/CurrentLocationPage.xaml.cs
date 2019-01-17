using System;
using System.Threading.Tasks;
using WeatherApp.Shared.ViewModels;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Shared.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentLocationPage
    {
        private readonly CurrentLocationPageViewModel _viewModel;

        public CurrentLocationPage()
        {
            Title = "※ Weather";
            BindingContext = _viewModel = new CurrentLocationPageViewModel();
            InitializeComponent();
        }

        protected async void GetWeatherButton_OnClickedAsync(object sender, EventArgs args)
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

        public async Task MasterPage_OnInputAsync(string name)
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