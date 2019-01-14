using System;
using System.Threading.Tasks;
using WeatherApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        private SearchPageViewModel _viewModel;

        public SearchPage()
        {
            BindingContext = _viewModel = new SearchPageViewModel();
            InitializeComponent();
        }

        public async void OnSearchButtonClickedAsync(object sender, EventArgs args)
        {
            await Task.CompletedTask;
        }
    }
}