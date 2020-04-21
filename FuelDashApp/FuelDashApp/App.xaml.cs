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
        public static int UserId { get; set; }
        public static double ScreenHeight { get; set; }
        public static double ScreenWidth { get; set; }
        public App()
        {
            InitializeComponent();

            var landingPage = new LandingPage();

            MainPage = new NavigationPage(landingPage);
        }

        protected override async void OnStart()
        {
            await CheckLoginAsync();
            base.OnStart();

        }
        public async System.Threading.Tasks.Task CheckLoginAsync()
        {
            if (Current.Properties.ContainsKey("UserId"))
            {
                //if (Current.MainPage.Navigation.NavigationStack.Count == 0 || Current.MainPage.Navigation.NavigationStack.GetType() != typeof(HomePage))
                //{
                //    await Current.MainPage.Navigation.PushAsync(new HomePage());
                //}
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
