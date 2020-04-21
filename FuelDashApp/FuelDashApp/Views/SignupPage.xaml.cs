using FuelDashApp.Services;
using FuelDashApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;

namespace FuelDashApp.Views
{
   // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : ContentPage
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
            await _vm.RegisterAsync();
            if (_vm.IsValid)
            {
                App.IsUserLoggedIn = true;
                Toast.LongAlert(_vm.Message);
                if (Navigation.NavigationStack.Count == 0 || Navigation.NavigationStack.Last().GetType() != typeof(HomePage))
                {
                    await Navigation.PushAsync(new HomePage());
                }
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