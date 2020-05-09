using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eVehicleDealership.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePasswordPage : ContentPage
    {
        public ChangePasswordPage()
        {
            InitializeComponent();
        }

        private async void BtnChangePassword_Clicked(object sender, EventArgs e)
        {
            var response = await APIService.ChangePassword(EntOldPassword.Text, EntNewPassword.Text, EntConfirmPassword.Text);
            if (!response)
            {
                await DisplayAlert("Error", "Došlo je do greške.", "Cancel");
            }
            else
            {
                await DisplayAlert("Lozinka uspješno promijenjena", "Molimo prijavite se koristeći novu lozinku.", "OK");
                Preferences.Set("access_token", string.Empty);
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
        }
    }
}