using eVehicleDealership.Modeli;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eVehicleDealership.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PretragaPage : ContentPage
    {
        public PretragaPage()
        {
            InitializeComponent();
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            LvPretraga.ItemsSource = await APIService.PretragaVozila(e.NewTextValue);
        }

        private void LvPretraga_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem as VoziloSearch;
            if (selectedItem.VoziloId != -1)
            {
                Navigation.PushModalAsync(new VoziloDetaljiPage(selectedItem.VoziloId));
            }
        }
    }
}