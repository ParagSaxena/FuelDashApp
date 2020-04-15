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
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent();
            this.BindingContext = new HomePageViewModel();
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        private void Logout_Tapped(object sender, EventArgs e)
        {

        }

        private void ProfileImage_Tapped(object sender, EventArgs e)
        {

        }

        private void Dashboard_Tapped(object sender, EventArgs e)
        {

        }

        private void JobSearch_Tapped(object sender, EventArgs e)
        {

        }

        private void Notification_Tapped(object sender, EventArgs e)
        {

        }

        private void Mail_Tapped(object sender, EventArgs e)
        {

        }

        private void Add_Tapped(object sender, EventArgs e)
        {

        }

        private void MenuItemListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {

        }

        private void ListView_QueryItemSize(object sender, Syncfusion.ListView.XForms.QueryItemSizeEventArgs e)
        {

        }
    }
}