using FuelDashApp.Services;
using FuelDashApp.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FuelDashApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GenerateQRPage : ContentPage
    {

        public GenerateQRPage()
        {
            InitializeComponent();
            this.BindingContext = new GeneratePasscodeViewModel();
        }
      
        public GeneratePasscodeViewModel ViewModel => this.BindingContext as GeneratePasscodeViewModel;
        private async void CancelImageOfPopUpTapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
             ViewModel.GetRolesAsync();
            base.OnAppearing();
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            var Toast = DependencyService.Get<IMessage>();
            await ViewModel.GeneratePasscode();
            if (ViewModel.IsValid)
            {
                Toast.LongAlert("Successfully send Passcode");
                if (Navigation.NavigationStack.Count == 0 || Navigation.NavigationStack.Last().GetType() != typeof(HomePage))
                {
                    await Navigation.PushAsync(new HomePage());
                }
            }
        }
    }
}