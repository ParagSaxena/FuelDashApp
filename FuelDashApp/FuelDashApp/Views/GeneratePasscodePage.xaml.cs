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
            UseWidth();
        }
      
        public GeneratePasscodeViewModel ViewModel => this.BindingContext as GeneratePasscodeViewModel;
       
        private void UseWidth()
        {
            //mainGrid.RowDefinitions.Add(new RowDefinition { Height = App.ScreenHeight * 0.319 });
            //mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            toolBar.ColumnDefinitions.Add(new ColumnDefinition { Width = App.ScreenWidth * 0.032 });
            backImage.HeightRequest = App.ScreenHeight * 0.0269;
            lblGeneratePass.FontSize = App.ScreenWidth * 0.0506;
        }
        private void GoBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
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