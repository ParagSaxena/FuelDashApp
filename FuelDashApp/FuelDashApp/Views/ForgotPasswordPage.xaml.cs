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
	public partial class ForgotPasswordPage : ContentPage
	{
		public ForgotPasswordPage ()
		{
			InitializeComponent ();
            this.BindingContext = new ForgotPasswordPageViewModel();
		}

        public ForgotPasswordPageViewModel ViewModel => this.BindingContext as ForgotPasswordPageViewModel;

        private async void SignIn_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignupPage());
        }

        private void ForgotPassword_Clicked(object sender, EventArgs e)
        {
            ViewModel.ForgotPasswordAsync();
        }

        private async void CancelImageOfPopUpTapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}