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
        private static WeatherContext _database;
        public static WeatherContext Database => _database
            ?? (_database = new WeatherContext(Path.Combine(Environment.GetFolderPath(LocalApplicationData), "WeatherAppDb.db3")));

        public App()
        {
            try
            {
                InitializeComponent();
                MainPage = new MainPage();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
