using FuelDashApp.Helper.Interface;
using FuelDashApp.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FuelDashApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditProfilePage : ContentPage
	{
        ImageSource _imageSource;
        ImageSource _browsedSource;
        private IMedia _mediaPicker;
        ImageSource image { get; set; }
        public SignupPageViewModel _vm; 
        public EditProfilePage (string name, string email)
		{
            try
            {
                InitializeComponent();
                _vm = new SignupPageViewModel(name, email);
                this.BindingContext = _vm;
            }
            catch(Exception ex)
            {

            }
        }

        private void Cancel_Tapped(object sender, EventArgs e)
        {
            //if (!App.Locator.NavigationService.CurrentPageKey.Contains(Locator.ProfileScreen))
            //{
            //    App.IsEditProfilePageOpened = true;
            //    App.Locator.NavigationService.NavigateTo(Locator.ProfileScreen, _vm.CandidateObj.CandidateId);
            //}
        }

        private async void GetImageButtonClicked_Tapped(object sender, EventArgs e)
        {

            var action = await DisplayActionSheet(null, "Cancel", null, "Photo Library", "Take Photo");
            if (action == "Photo Library")
                await SelectPicture();
            else if (action == "Take Photo")
                await TakePicture();
            else if (action == "Cancel")
                return;
        }

        #region Photos

        private async void Setup()
        {
            if (_mediaPicker != null)
            {
                return;
            }

            ////RM: hack for working on windows phone? 
            await CrossMedia.Current.Initialize();
            _mediaPicker = CrossMedia.Current;
        }

        private async Task SelectPicture()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                return;
            }
            MediaFile file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null)
            {
                return;
            }
            try
            {
                byte[] cropedBytes = await CrossXMethod.Current.CropImageFromOriginalToBytes(file.Path);
                byte[] resizeByte = DependencyService.Get<FuelDashApp.Helper.Interface.IMediaService>().ResizeImage(cropedBytes, 100, 100);
                if (resizeByte != null)
                {
                    FileInfo fi = new FileInfo(file.Path);
                    //_vm.ImageLength = fi.Length;
                    //_vm.ImageName = fi.Name;
                    //_imageSource = ImageSource.FromStream(file.GetStream);
                    //image = _imageSource;
                    //_vm.ImageAsByte = resizeByte;
                    //_vm.EditImage = _imageSource;
                    //_vm.ImagePath = file.Path;

                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private async Task TakePicture()
        {
            await CrossMedia.Current.Initialize();
            _imageSource = null;

            try
            {
                MediaFile mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    SaveToAlbum = true,
                    DefaultCamera = CameraDevice.Rear

                });
                if (mediaFile == null)
                {
                    return;
                }

                byte[] cropedBytes = await CrossXMethod.Current.CropImageFromOriginalToBytes(mediaFile.Path);
                byte[] resizeByte = DependencyService.Get<FuelDashApp.Helper.Interface.IMediaService>().ResizeImage(cropedBytes, 100, 100);
                if (resizeByte != null)
                {
                    FileInfo fi = new FileInfo(mediaFile.Path);
                    //_vm.ImageName = fi.Name;
                    if (resizeByte != null)
                    {
                        ImageSource AvatarImageSource = ImageSource.FromStream(() =>
                        {
                            var cropedImage = new MemoryStream(resizeByte);
                           // _vm.ImageLength = cropedImage.Length;
                            mediaFile.Dispose();
                            return cropedImage;
                        });
                      //  _imageSource = AvatarImageSource;
                    }
                    else
                    {
                        mediaFile.Dispose();
                    }

                    //image = _imageSource;
                    //_vm.ImageAsByte = resizeByte;
                    //_vm.EditImage = _imageSource;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        #endregion

        private async void EditProfile_Tapped(object sender, EventArgs e)
        { }

            private async void Signup_Clicked(object sender, EventArgs e)
        {
            if (Navigation.NavigationStack.Count == 0 || Navigation.NavigationStack.Last().GetType() != typeof(SignupPage))
            {
                await Navigation.PushAsync(new SignupPage());
            }
        }
    }
}