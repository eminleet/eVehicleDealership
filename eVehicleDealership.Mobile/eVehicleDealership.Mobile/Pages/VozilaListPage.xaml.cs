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
    public partial class VozilaListPage : ContentPage
    {
        public ObservableCollection<VoziloPoKategoriji> vozilaCollection;
        public VozilaListPage(int kategorijaId)
        {
            InitializeComponent();
            vozilaCollection = new ObservableCollection<VoziloPoKategoriji>();
            GetVozila(kategorijaId);
        }

        private async void GetVozila(int kategorijaId)
        {
            var vozila = await APIService.GetVozilaPoKategoriji(kategorijaId);
            foreach (var item in vozila)
            {
                vozilaCollection.Add(item);
            }
            LvVozila.ItemsSource = vozilaCollection;
        }

        private void LvVozila_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var voziloId = (e.SelectedItem as VoziloPoKategoriji).VoziloId;
            Navigation.PushModalAsync(new VoziloDetaljiPage(voziloId));
        }

        private void BtnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}