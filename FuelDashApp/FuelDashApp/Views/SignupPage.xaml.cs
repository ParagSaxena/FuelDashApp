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
       
        public SignupPage()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            //var security = "";
            //var ssidHidden = "";

            //   ssidHidden = "H:false";

            //BarcodeImageView.BarcodeValue = $"WIFI:S:{"Rachna"};T:{security};P:{"Mishra.rachna.90@gmail.com"};{ssidHidden};";

            //BarcodeImageView.IsVisible = true;
            // _vm.GetRolesAsync();
            base.OnAppearing();
        }

        public async void Handle_OnScanResult(Result result)
        {
            string name = "";  string email = "";
            Device.BeginInvokeOnMainThread(async () =>
            {
               // await Navigation.PopAsync();
                if (!String.IsNullOrEmpty(email))
                {
                    await Navigation.PushAsync(new EditProfilePage(name, email));
                }
            });
            try
            {
                if (string.IsNullOrWhiteSpace(result.Text))
                    return;
                if (!result.Text.ToUpperInvariant().StartsWith("WIFI:", StringComparison.Ordinal))
                    return;
                var text = result.Text.Split(';');
                 name = text[0].Replace("WIFI:S:", "");
                 email = text[2].Replace("P:", "");
                //if (Navigation.NavigationStack.Count == 0 || Navigation.NavigationStack.Last().GetType() != typeof(EditProfilePage))
                //{
                //    await Navigation.PushAsync(new EditProfilePage(name, email));
                //}
               
            }
            catch(Exception ex)
            {

            }
        }



        }
}