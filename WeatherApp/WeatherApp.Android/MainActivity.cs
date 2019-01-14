using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using System;
using Xamarin.Essentials;

namespace WeatherApp.Droid
{
    [Activity(Label = "WeatherApp",
        Icon = "@mipmap/icon",
        Theme = "@style/MainTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                TabLayoutResource = Resource.Layout.Tabbar;
                ToolbarResource = Resource.Layout.Toolbar;

                base.OnCreate(savedInstanceState);
                Instance = this;
                Xamarin.Forms.Forms.Init(this, savedInstanceState);
                Platform.Init(this, savedInstanceState);

                LoadApplication(new App());
            }
            catch (Exception ex)
            {
                // ignored
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}