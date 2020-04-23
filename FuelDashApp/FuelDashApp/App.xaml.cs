using FuelDashApp.Helper;
using FuelDashApp.Helper.Interface;
using FuelDashApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FuelDashApp
{
    public partial class App : Application
    {
        public static bool IsPopupButtonEnable { get; set; }
        public static bool IsUserLoggedIn { get; set; }
        public static string UserEmail { get; set; }
        public static string Password { get; set; }
        private static Locator _locator;
        public static Locator Locator
        {
            get
            {
                return _locator ?? (_locator = new Locator());
            }
        }
        public static int UserId { get; set; }
        public static double ScreenHeight { get; set; }
        public static double ScreenWidth { get; set; }
        public static bool IsDeviceIphone { get; set; }
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("OTg4NzhAMzEzNzJlMzEyZTMwZ3doZFZhZHRhbjRuMnU3TkpGWTFvSjNLbk5ZZmt1Z0c0OUFJUDJKRGVjcz0=");
            if (Device.RuntimePlatform == Device.iOS)
            {
                IsDeviceIphone = DependencyService.Get<IDeviceInfo>().IsIphoneXDevice();
            }
            InitializeComponent();

            Xamarin.Forms.NavigationPage navigationPage;
            Xamarin.Forms.Page pageType = new LandingPage();

            navigationPage = new Xamarin.Forms.NavigationPage(pageType)
            {
                BarTextColor = Color.White,
                BarBackgroundColor = Color.FromHex("#AF1E2D"),

            };
            GetFontSize();
            Locator.NavigationService.Initialize(navigationPage);
            UserEmail= String.Empty;
            Password = String.Empty;
            if (!Current.Properties.ContainsKey("IsUserLoggedIn"))
            {
                Current.Properties["IsUserLoggedIn"] = false;
                Xamarin.Forms.Application.Current.SavePropertiesAsync();
                MainPage = navigationPage;
            }
            else
            {
                if (Convert.ToBoolean(Current.Properties["IsUserLoggedIn"]) == true)
                {
                    MainPage = new Xamarin.Forms.NavigationPage(new HomePage());
                }
                else
                {
                    MainPage = navigationPage;
                }
            }
        }

        protected override async void OnStart()
        {
            await CheckLoginAsync();
            base.OnStart();


        }

        public void GetFontSize()
        {
            Xamarin.Forms.Application.Current.Resources["LabelFontSize10"] = 10d / 667d * ScreenHeight;
            Xamarin.Forms.Application.Current.Resources["LabelFontSize12"] = 12d / 667d * ScreenHeight;
            Xamarin.Forms.Application.Current.Resources["LabelFontSize14"] = 14d / 667d * ScreenHeight;
            Xamarin.Forms.Application.Current.Resources["LabelFontSize16"] = 16d / 667d * ScreenHeight;
            Xamarin.Forms.Application.Current.Resources["LabelFontSize18"] = 18d / 667d * ScreenHeight;
            Xamarin.Forms.Application.Current.Resources["RatingsListHeight"] = 90d / 375d * ScreenWidth;
            Xamarin.Forms.Application.Current.Resources["RatingsListWidth"] = 170d / 375d * ScreenWidth;
            Xamarin.Forms.Application.Current.Resources["MyDocumentHeight"] = 22d / 375d * ScreenWidth;
            Xamarin.Forms.Application.Current.Resources["StarSize"] = 23d / 667d * ScreenHeight;
            Xamarin.Forms.Application.Current.Resources["StarWidth"] = 151d / 667d * ScreenHeight;
            Xamarin.Forms.Application.Current.Resources["PdfHeight"] = 30d / 667d * ScreenHeight;
            Xamarin.Forms.Application.Current.Resources["PdfWidth"] = 28d / 667d * ScreenHeight;
            Xamarin.Forms.Application.Current.Resources["RatingItemWidth"] = 170d / 375d * ScreenWidth;
            Xamarin.Forms.Application.Current.Resources["MyDocumentListSize"] = 14d / 667d * ScreenHeight;
            Xamarin.Forms.Application.Current.Resources["LocationIcon"] = 12d / 667d * ScreenHeight;
            Xamarin.Forms.Application.Current.Resources["FlagHeight"] = 24d / 667d * ScreenHeight;
            Xamarin.Forms.Application.Current.Resources["Profilestar"] = 12d / 667d * ScreenHeight;
            Xamarin.Forms.Application.Current.Resources["Star"] = 24d / 667d * ScreenHeight;
            Xamarin.Forms.Application.Current.Resources["MyjobItemSpacing"] = 10d / 667d * ScreenHeight;
            Xamarin.Forms.Application.Current.Resources["CompletedItemSpacing"] = 22d / 667d * ScreenHeight;
            Xamarin.Forms.Application.Current.Resources["SwapItemSize"] = 50d / 667d * ScreenHeight;
            Xamarin.Forms.Application.Current.Resources["DaysItemSize"] = 27d / 667d * ScreenHeight;
            Xamarin.Forms.Application.Current.Resources["ResumeBuilderWidth"] = 325d / 667d * ScreenHeight;
            Xamarin.Forms.Application.Current.Resources["ResumeBuilderHeight"] = 40d / 667d * ScreenHeight;
        }
        public async System.Threading.Tasks.Task CheckLoginAsync()
        {
            if (Current.Properties.ContainsKey("UserId"))
            {
                if (!App.Locator.NavigationService.CurrentPageKey.Contains(Locator.HomePage))
                {
                    await Current.MainPage.Navigation.PushAsync(new HomePage());
                }
                else
                {
                    await Current.MainPage.Navigation.PushAsync(new LandingPage());
                }
            }
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
