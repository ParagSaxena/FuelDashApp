using FuelDashApp.Helper;
using FuelDashApp.Helper.Interface;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FuelDashApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SubMenu : PopupPage
    {
		public SubMenu ()
		{
			InitializeComponent ();
            UseWidth();
        }
        private void UseWidth()
        {
            GeneratePasscodebtn.HeightRequest = 40;
            GeneratePasscodebtn.WidthRequest = 120;
            LogoutButton.HeightRequest = 40;
            LogoutButton.WidthRequest = 120;
            MyInsiderButton.HeightRequest = 40;
            MyInsiderButton.WidthRequest = 120;

            CrossImage.HeightRequest = 90;
            CrossImage.WidthRequest = 90;
            MyInsiderImage.HeightRequest = 70;
            MyInsiderImage.WidthRequest = 70;
            LogoutImage.HeightRequest = 70;
            LogoutImage.WidthRequest = 70;
            GeneratePasscodeImage.HeightRequest = 70;
            GeneratePasscodeImage.WidthRequest = 70;
            CrossImageStack.HeightRequest = 90;
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        // ### Methods for supporting animations in your popup page ###

        // Invoked before an animation appearing
        protected override void OnAppearingAnimationBegin()
        {
            base.OnAppearingAnimationBegin();
        }

        // Invoked after an animation appearing
        protected override void OnAppearingAnimationEnd()
        {
            base.OnAppearingAnimationEnd();
        }

        // Invoked before an animation disappearing
        protected override void OnDisappearingAnimationBegin()
        {
            base.OnDisappearingAnimationBegin();
        }

        // Invoked after an animation disappearing
        protected override void OnDisappearingAnimationEnd()
        {
            base.OnDisappearingAnimationEnd();
        }

        protected override Task OnAppearingAnimationBeginAsync()
        {
            return base.OnAppearingAnimationBeginAsync();
        }

        protected override Task OnAppearingAnimationEndAsync()
        {
            return base.OnAppearingAnimationEndAsync();
        }

        protected override Task OnDisappearingAnimationBeginAsync()
        {
            return base.OnDisappearingAnimationBeginAsync();
        }

        protected override Task OnDisappearingAnimationEndAsync()
        {
            //  App.Locator.NavigationService.NavigateTo(Locator.ResumeBuilder);


            return base.OnDisappearingAnimationEndAsync();
        }

        // ### Overrided methods which can prevent closing a popup page ###

        // Invoked when a hardware back button is pressed
        protected override bool OnBackButtonPressed()
        {
            // Return true if you don't want to close this popup page when a back button is pressed
            return base.OnBackButtonPressed();
        }

        // Invoced when background is clicked
        protected override bool OnBackgroundClicked()
        {
            // Return false if you don't want to close this popup page when a background of the popup page is clicked
            return base.OnBackgroundClicked();
        }

        private async void CloseButton_Tapped(object sender, System.EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }

        private async void GeneratePasscode_Tapped(object sender, System.EventArgs e)
        {
            if (!App.Locator.NavigationService.CurrentPageKey.Contains(Locator.GeneratePassCode))
            {
                App.Locator.NavigationService.NavigateTo(Locator.GeneratePassCode);
                await Navigation.PopPopupAsync();
            }

        }
        private async void Availability_Tapped(object sender, System.EventArgs e)
        {
            try
            {
                App.IsUserLoggedIn = false;
                App.UserId = 0;
                App.UserEmail = "";
                App.Password = "";
                DependencyService.Get<IClearCookies>().Clear();
                Xamarin.Forms.Application.Current.Properties.Clear();
                await App.Current.MainPage.Navigation.PushAsync(new LandingPage(), true);
                await Navigation.PopPopupAsync();
            }
            catch (Exception ex)
            {
            }
        }
        private async void Insider_Tapped(object sender, System.EventArgs e)
        {
           
        }
    }
}