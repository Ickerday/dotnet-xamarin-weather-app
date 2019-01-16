using System;
using WeatherApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            SearchMaster.PreviousCitiesListView.ItemSelected += OnPreviousCitySelected;
            SearchMaster.CityEntry.Completed += OnSearchCompleted;
            SearchMaster.SearchButton.Clicked += OnSearchCompleted;
        }

        public void OnStart()
        {
            LocationDetail.OnStart();
            SearchMaster.OnStart();
        }

        public async void OnPreviousCitySelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is SearchPageListItem item))
                return;

            await LocationDetail.OnInputFromMasterPageAsync(item.Name);
            SearchMaster.PreviousCitiesListView.SelectedItem = null;
            IsPresented = false;
        }

        public async void OnSearchCompleted(object sender, EventArgs e)
        {
            var cityEntry = SearchMaster.CityEntry.Text;
            if (string.IsNullOrEmpty(cityEntry))
                return;

            SearchMaster.CityEntry.Text = string.Empty;

            await LocationDetail.OnInputFromMasterPageAsync(cityEntry);
            IsPresented = false;
        }
    }
}