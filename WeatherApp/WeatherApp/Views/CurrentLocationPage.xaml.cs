using System;
using WeatherApp.Exceptions;
using WeatherApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentLocationPage : ContentPage
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
                throw new AppException("Couldn't get weather for your location.", ex);
            }
        }
    }
}