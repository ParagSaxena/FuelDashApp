using FuelDashApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FuelDashApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent();
            this.BindingContext = new LoginPageViewModel();
		}

        public LoginPageViewModel ViewModel => this.BindingContext as LoginPageViewModel;

        private async void CancelImageOfPopUpTapped(object sender, EventArgs e)
        {
           await Navigation.PopAsync();
        }

        private async void ForgotPassword_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgotPasswordPage());
        }

        private async void Signup_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignupPage());
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            await ViewModel.LoginAsync();
        }

    }
}