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
			InitializeComponent ();
            UseWidth();
        }
        private void UseWidth()
        {
            toolBar.ColumnDefinitions.Add(new ColumnDefinition { Width = App.ScreenWidth * 0.032 });
            //backImage.HeightRequest = App.ScreenHeight * 0.0269;
            getReadyText.FontSize = App.ScreenWidth * 0.0506;
        }
       
        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

    }
}