using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using WeatherApp.Shared;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Application = Android.App.Application;
using Platform = Xamarin.Essentials.Platform;

namespace WeatherApp.Droid
{
    [Activity(Label = "※ Weather",
        Icon = "@mipmap/icon",
        Theme = "@style/MainTheme.Splash",
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
                base.Window.RequestFeature(WindowFeatures.ActionBar);
                base.SetTheme(Resource.Style.MainTheme);

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

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
            [GeneratedEnum] Permission[] grantResults)
        {
            // Required by Xamarin.Essentials
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.SettingsMenu, menu);
            return base.OnPrepareOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.settings_temp_unit:
                    Toast.MakeText(Application.Context, "Test 0", ToastLength.Short)
                        .Show();
                    return true;
                case Resource.Id.settings_about:
                    Toast.MakeText(Application.Context, "Test 1", ToastLength.Short)
                        .Show();
                    return true;
                default:
                    Toast.MakeText(Application.Context, "Invalid option selected", ToastLength.Short)
                        .Show();
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}