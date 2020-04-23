using FuelDashApp.Helper;
using FuelDashApp.Services;
using FuelDashApp.ViewModels;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FuelDashApp.Views
{
    // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : PopupPage
    {

        public SignupPageViewModel _vm;
        public SignupPage()
        {
            InitializeComponent();
            _vm = new SignupPageViewModel();
            this.BindingContext = _vm;
        }

        protected override void OnAppearing()
        {
           // _vm.GetRolesAsync();
            base.OnAppearing();
        }

        private async void CancelImageOfPopUpTapped(object sender, EventArgs e)
        {
            App.IsPopupButtonEnable = true;
            await Navigation.PopAsync();
        }


        public async void Login_Tapped(object sender, EventArgs e)
        {
            if (Navigation.NavigationStack.Count == 0 || Navigation.NavigationStack.Last().GetType() != typeof(LoginPage))
            {
                await Navigation.PopAsync();
                await Navigation.PushAsync(new LoginPage());
            }
        }

        private async void SignupButton_Clicked(object sender, EventArgs e)
        {

            var Toast = DependencyService.Get<IMessage>();
          await  ValidateForm();
            if (_vm.IsValid)
            {
                await _vm.RegisterAsync(); 
               
                    App.IsUserLoggedIn = true;
                    Toast.LongAlert(_vm.Message);
                    if (App.Locator.NavigationService.CurrentPageKey == null || App.Locator.NavigationService.CurrentPageKey.Contains(Locator.HomePage))
                    {
                        await Navigation.PushAsync(new HomePage());
                        await Navigation.PopPopupAsync();
                    }
                }
            }

        private async Task ValidateForm()
        {
            _vm.IsValid = true;
            var Toast = DependencyService.Get<IMessage>();
            if (String.IsNullOrEmpty(_vm.Passcode))
            {
                Toast.LongAlert("Passcode is required."); _vm.IsValid = false; return;
            }
            if (String.IsNullOrEmpty(_vm.FirstName))
            {
                Toast.LongAlert("First name is required."); _vm.IsValid = false; return;
            }
            if (String.IsNullOrEmpty(_vm.LastName))
            {
                Toast.LongAlert("Last name is required."); _vm.IsValid = false; return;
            }
            if (String.IsNullOrEmpty(_vm.Email))
            {
                Toast.LongAlert("Email is required."); _vm.IsValid = false; return;
            }
            if (!Regex.IsMatch(_vm.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                Toast.LongAlert("Invalid email address."); _vm.IsValid = false; return;
            }


            await _vm.IsEmailExsitAsync();
            if (_vm.IsMailExist)
            {
                Toast.LongAlert("Email already exist.Please use Login or Forgot password option of app."); _vm.IsValid = false; return;
            }
            if (!Regex.IsMatch(_vm.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                Toast.LongAlert("Invalid email address."); _vm.IsValid = false; return;
            }
            if (String.IsNullOrEmpty(_vm.Password))
            {
                Toast.LongAlert("Password is required."); _vm.IsValid = false; return;
            }
            if (String.IsNullOrEmpty(_vm.ConfirmPassword))
            {
                Toast.LongAlert("Confirm password is required."); _vm.IsValid = false; return;
            }
            if (_vm.Password != _vm.ConfirmPassword)
            {
                Toast.LongAlert("Confirm password is not matched."); _vm.IsValid = false; return;
            }
            await _vm.IsCorrectPassCodeAsync();
            if (_vm.PassCodeData== null || (_vm.PassCodeData.LastOrDefault().PassCode != _vm.Passcode && !_vm.PassCodeData.LastOrDefault().IsSignedUp))
            {
                Toast.LongAlert("Passcode is not matched.Please enter correct passcode."); _vm.IsValid = false; return;
            }
            if (_vm.PassCodeData.LastOrDefault().IsSignedUp)
            {
                Toast.LongAlert("You already have FuelDash account. Please use Login or Forgot password option of app."); _vm.IsValid = false; return;
            }
        }
  

       
        protected override bool OnBackButtonPressed()
        {
            return true;
        }



        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

    }
}