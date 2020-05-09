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
    public partial class ChangePhoneNumberPage : ContentPage
    {
        public ChangePhoneNumberPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            LblPhoneNumber.Text = "Trenutni broj telefona: " + await APIService.GetPhoneNumber();
        }

        private async void BtnChangePhoneNumber_Clicked(object sender, EventArgs e)
        {
            var response = await APIService.ChangePhoneNumber(EntPhoneNumber.Text);
            if (!response)
            {
                await DisplayAlert("Error", "Došlo je do greške.", "Cancel");
            }
            else
            {
                await DisplayAlert("Notifikacija", "Broj telefona uspješno promijenjen.", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}