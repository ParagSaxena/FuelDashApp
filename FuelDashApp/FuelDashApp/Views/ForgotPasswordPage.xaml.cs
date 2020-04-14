using FuelDashApp.Models;
using FuelDashApp.Services;
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
            if (Navigation.NavigationStack.Count == 0 || Navigation.NavigationStack.Last().GetType() != typeof(SignupPage))
            {
                await Navigation.PushAsync(new SignupPage());
            }
        }

        private async void ForgotPassword_Clicked(object sender, EventArgs e)
        {
            BaseResponse response=await ViewModel.ForgotPasswordAsync();
            var Toast = DependencyService.Get<IMessage>();
            Toast.LongAlert(response.Message); 
        }

        private async void CancelImageOfPopUpTapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}