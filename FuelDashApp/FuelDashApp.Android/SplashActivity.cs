
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace FuelDashApp.Droid
{
    [Activity(MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Splash",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            System.Threading.Thread.Sleep(3000);
            StartActivity(typeof(MainActivity));
        }
    }
}