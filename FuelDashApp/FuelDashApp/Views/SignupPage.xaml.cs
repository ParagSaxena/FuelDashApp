﻿using System;
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
			InitializeComponent ();
		}

        private async void CancelImageOfPopUpTapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        public void Login_Tapped(object sender, EventArgs e)
        {
           
        }
    }
}