using FuelDashApp.Helper;
using FuelDashApp.Services;
using FuelDashApp.ViewModels;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FuelDashApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : PopupPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginPageViewModel();
        }

        public LoginPageViewModel ViewModel => this.BindingContext as LoginPageViewModel;
        private void OnCloseButtonTapped(object sender, EventArgs e)
        {
            App.IsPopupButtonEnable = true;
            CloseAllPopup();
        }
        private async void CloseAllPopup()
        {
            App.IsPopupButtonEnable = true;
            await Navigation.PopAllPopupAsync();
        }
        private async void CancelImageOfPopUpTapped(object sender, EventArgs e)
        {
            App.IsPopupButtonEnable = true;
            await Navigation.PopPopupAsync();
        }

        private async void ForgotPassword_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
            await Navigation.PushPopupAsync(new ForgotPasswordPage());
           
        }

        private async void Signup_Tapped(object sender, EventArgs e)
        {

            await Navigation.PopPopupAsync();
            await Navigation.PushPopupAsync(new SignupPage());
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            await ViewModel.LoginAsync();
            if (ViewModel.IsValid)
            {
                App.IsUserLoggedIn = true;
                if (App.Locator.NavigationService.CurrentPageKey==null ||App.Locator.NavigationService.CurrentPageKey.Contains(Locator.HomePage))
                {
                     App.Locator.NavigationService.NavigateTo(Locator.HomePage);
                    await Navigation.PopPopupAsync();
                }
            }
            else
            {
                var Toast = DependencyService.Get<IMessage>();
                Toast.LongAlert("Login failed.");
            }
        }

    }
}