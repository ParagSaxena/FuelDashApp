using Rg.Plugins.Popup.Services;

using Rg.Plugins.Popup.Extensions;
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
            App.IsPopupButtonEnable = true;

        }
        private async void Login_Clicked(object sender, EventArgs e)
        {
            if (App.IsPopupButtonEnable)
            {
                if (Navigation.NavigationStack[Navigation.NavigationStack.Count - 1].GetType() != typeof(LoginPage))
                {
                    App.IsPopupButtonEnable = false;
                    await PopupNavigation.Instance.PushAsync(new LoginPage());

                }
            }
        }
        private async void Signup_Clicked(object sender, EventArgs e)
        {
            if (App.IsPopupButtonEnable)
            {
                if (Navigation.NavigationStack[Navigation.NavigationStack.Count - 1].GetType() != typeof(SignupPage))
                {
                    App.IsPopupButtonEnable = false;
                    await Navigation.PushPopupAsync(new SignupPage(), false);
                }
            }
        }

    }
}