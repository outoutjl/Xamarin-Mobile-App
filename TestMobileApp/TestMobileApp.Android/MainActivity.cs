
using Android.App;
using Android.Content.PM;
using Android.OS;
using Plugin.Fingerprint;
using Plugin.CurrentActivity;

namespace TestMobileApp.Droid
{
    [Activity(Label = "TestMobileApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //1. Init for Finger Print. 
            //Possible Issue: https://github.com/smstuebe/xamarin-fingerprint/issues/112#issuecomment-425380224
            //CrossFingerprint.SetCurrentActivityResolver(() => CrossCurrentActivity.Current.Activity); //This may cause object not set to an instance of an object reference. 
            CrossFingerprint.SetCurrentActivityResolver(() => this);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}