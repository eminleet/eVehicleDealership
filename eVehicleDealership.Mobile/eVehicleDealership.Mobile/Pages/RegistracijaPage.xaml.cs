using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eVehicleDealership.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistracijaPage : ContentPage
    {
        public RegistracijaPage()
        {
            InitializeComponent();
        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            var response = await APIService.RegisterUser(EntIme.Text, EntPrezime.Text, EntEmail.Text, EntTelefon.Text, EntLozinka.Text, EntLozinkaPotvrda.Text);
            if (response)
            {
                await DisplayAlert("Notifikacija", "Korisnički nalog uspješno kreiran!", "OK");
                await Navigation.PushModalAsync(new LoginPage());
            }
            else
            {
                EntLozinka.Text = "";
                EntLozinkaPotvrda.Text = "";
                await DisplayAlert("Notifikacija", "Došlo je do greške prilikom kreiranja korisničkog naloga.", "Cancel");
            }
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }

        private async void BtnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void EntLozinkaPotvrda_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(EntLozinka.Text != EntLozinkaPotvrda.Text)
            {
                LblPotvrdaLozinkeWarning.IsVisible = true;
            }
            else
            {
                LblPotvrdaLozinkeWarning.IsVisible = false;
            }
        }
    }
}