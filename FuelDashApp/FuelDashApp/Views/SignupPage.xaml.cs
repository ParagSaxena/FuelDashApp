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
	public partial class SignupPage : ContentPage
	{
		public SignupPage ()
		{
			InitializeComponent();
            this.BindingContext = new SignupPageViewModel();
        }

        public SignupPageViewModel ViewModel => this.BindingContext as SignupPageViewModel;

        protected override void OnAppearing()
        {
            ViewModel.GetRolesAsync();
            base.OnAppearing();
        }

        private async void CancelImageOfPopUpTapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        public void Login_Tapped(object sender, EventArgs e)
        {
           
        }

        private void SignupButton_Clicked(object sender, EventArgs e)
        {
            ViewModel.RegisterAsync();
        }
    }
}