using FuelDashApp.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FuelDashApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateActivityPage : ContentPage
	{
		public CreateActivityPage()
		{
			InitializeComponent ();
            this.BindingContext = new CreateActivityPageViewModel();
		}

        public CreateActivityPageViewModel ViewModel => this.BindingContext as CreateActivityPageViewModel;

        protected override void OnAppearing()
        {
            ViewModel.GetDepartmentsAsync();
            ViewModel.GetPrioritiesAsync();
            ViewModel.GetSitesAsync();
            base.OnAppearing();
        }

        private void FormatEmail_Clicked(object sender, EventArgs e)
        {
            ViewModel.ParseEamil(EmailTextEditor.Text);
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            ViewModel.CreateWorkOrderAsync();
        }
    }
}