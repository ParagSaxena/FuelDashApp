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
	public partial class LandingPage : ContentPage
	{
		public LandingPage ()
		{
			InitializeComponent ();
		}
        private async void Login_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
        private async void Signup_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignupPage());
        }

    }
}