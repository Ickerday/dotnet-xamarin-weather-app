using System;
using WeatherApp.Shared.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Shared.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            SearchMaster.PreviousCitiesListView.ItemSelected += PreviousCities_OnItemSelectedAsync;
            SearchMaster.CityEntry.Completed += Search_OnCompletedAsync;
            SearchMaster.SearchButton.Clicked += Search_OnCompletedAsync;
        }

        public void OnStart()
        {
            LocationDetail.OnStart();
            SearchMaster.OnStart();
        }

        public async void PreviousCities_OnItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is SearchPageListItem item))
                return;

            await LocationDetail.MasterPage_OnInputAsync(item.Name);
            SearchMaster.PreviousCitiesListView.SelectedItem = null;
        }

        public async void Search_OnCompletedAsync(object sender, EventArgs e)
        {
            var cityEntry = SearchMaster.CityEntry.Text;
            if (string.IsNullOrEmpty(cityEntry))
                return;

            SearchMaster.CityEntry.Text = string.Empty;

            await LocationDetail.MasterPage_OnInputAsync(cityEntry);
        }
    }
}