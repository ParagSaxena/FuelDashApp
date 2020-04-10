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
			InitializeComponent ();
		}
        private async void CancelImageOfPopUpTapped(object sender, EventArgs e)
        {
           await Navigation.PopAsync();
        }

        private void ForgotPassword_Tapped(object sender, EventArgs e)
        {
           
        }

        private void Signup_Tapped(object sender, EventArgs e)
        {

        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
           
        }

    }
}