using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Application = Android.App.Application;
using Platform = Xamarin.Essentials.Platform;

namespace WeatherApp.Droid
{
    [Activity(Label = "WeatherApp",
        Icon = "@mipmap/icon",
        Theme = "@style/MainTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                TabLayoutResource = Resource.Layout.Tabbar;
                ToolbarResource = Resource.Layout.Toolbar;
                base.OnCreate(savedInstanceState);

                Forms.Init(this, savedInstanceState);
                Platform.Init(this, savedInstanceState);

                LoadApplication(new App());
            }
            catch (Exception ex)
            {
                Toast.MakeText(Application.Context, ex.Message, ToastLength.Short)
                    .Show();
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            // Required by Xamarin.Essentials
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}