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
    public partial class MojiOglasiPage : ContentPage
    {

        public ObservableCollection<MojOglas> MojiOglasiCollection = new ObservableCollection<MojOglas>();
        public MojiOglasiPage()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            MojiOglasiCollection.Clear();
            GetVozila();
        }

        private async void GetVozila()
        {
            var vozila = await APIService.GetMojeOglase();
            foreach (var item in vozila)
            {
                MojiOglasiCollection.Add(item);
            }
            LvVozila.ItemsSource = MojiOglasiCollection;
        }

        private void LvVozila_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var voziloId = (e.SelectedItem as MojOglas).VoziloId;
            Navigation.PushModalAsync(new VoziloDetaljiPage(voziloId));
        }
    }
}