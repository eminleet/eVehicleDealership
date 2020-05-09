using ImageToArray;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eVehicleDealership.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        private MediaFile file;
        public ProfilePage()
        {
            InitializeComponent();
        }

        private void TapUploadImage_Tapped(object sender, EventArgs e)
        {
            PickImageFromGallery();
        }

        private async void PickImageFromGallery()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Oops", "Žao nam je, Vaš uređaj ne dozvoljava ovu funkcionalnost.", "OK");
                return;
            }

            PickMediaOptions pick = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Small,
                CompressionQuality = 92
            };
            file = await CrossMedia.Current.PickPhotoAsync(pick);

            if (file == null)
                return;

            ImgProfile.Source = ImageSource.FromStream(() => file.GetStream());
            AddImageToServer();
        }

        private async void AddImageToServer()
        {
            var imageArray = FromFile.ToArray(file.GetStream());

            var response = await APIService.ChangeProfilePicture(imageArray);
            if (response) return;
            await DisplayAlert("Error", "Došlo je do greške. Ponovite upload slike.", "OK");
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var profileImage = await APIService.GetProfilePicture();
            if (profileImage.imageArray != null && profileImage.imageArray.Length > 0)
            {
                Stream stream = new MemoryStream(profileImage.imageArray);
                ImgProfile.Source = ImageSource.FromStream(() => stream);
            }
            else
            {
                ImgProfile.Source = "userPlaceholder.png";
            }
        }

        private void TapChangePassword_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangePasswordPage());
        }

        private void TapChangePhone_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangePhoneNumberPage());
        }

        private void TapLogout_Tapped(object sender, EventArgs e)
        {
            Preferences.Set("access_token", string.Empty);
            Preferences.Set("token_expiration_time", DateTime.Now.AddYears(-1));
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}