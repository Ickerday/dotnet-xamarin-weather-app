using System;
using System.IO;
using WeatherApp.Infrastructure;
using WeatherApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Environment.SpecialFolder;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WeatherApp
{
    public partial class App : Application
    {
        private static readonly string DbPath = Path.Combine(Environment.GetFolderPath(LocalApplicationData), "WeatherAppDb.db3");

        private static WeatherContext _database;
        private readonly MainPage _masterDetailPage;

        public static WeatherContext Database => _database
            ?? (_database = new WeatherContext(DbPath));

        public App()
        {
            InitializeComponent();
            MainPage = _masterDetailPage = new MainPage();
        }

        protected override void OnStart()
        {
            _masterDetailPage.OnStart();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
