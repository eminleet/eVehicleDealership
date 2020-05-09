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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            var response = await APIService.Login(EntEmail.Text, EntPassword.Text);
            if (response)
            {
                Preferences.Set("userEmail", EntEmail.Text);
                Preferences.Set("userPassword", EntPassword.Text);
                Application.Current.MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                await DisplayAlert("Notifikacija", "Neuspješna prijava na sistem.", "Cancel");
            }
        }

        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegistracijaPage());
        }
    }
}