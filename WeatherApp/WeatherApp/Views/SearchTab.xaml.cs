using WeatherApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class SearchTabPage : ContentPage
    {
        private SearchTabViewModel _viewModel;

        public SearchTabPage(SearchTabViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = _viewModel = viewModel;
        }

        public SearchTabPage()
        {
            InitializeComponent();
        }

        private static void InitializeComponent()
        {
            throw new System.NotImplementedException();
        }
    }
}