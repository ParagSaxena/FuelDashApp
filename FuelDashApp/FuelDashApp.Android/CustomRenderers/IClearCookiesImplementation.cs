using Android.Webkit;
using FuelDashApp.Droid.CustomRenderers;
using FuelDashApp.Helper.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(IClearCookiesImplementation))]
namespace FuelDashApp.Droid.CustomRenderers
{
    public class IClearCookiesImplementation : IClearCookies

    {
        public void Clear()
        {
            var cookieManager = CookieManager.Instance;
            cookieManager.RemoveAllCookie();
        }
    }
}