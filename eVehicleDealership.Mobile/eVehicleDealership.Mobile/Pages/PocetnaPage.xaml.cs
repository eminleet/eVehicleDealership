using eVehicleDealership.Modeli;
using ImageToArray;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eVehicleDealership.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PocetnaPage : ContentPage
    {
        private int Motocikli_ID = 1;
        private int Automobili_ID = 2;
        private int TeretnaVozila_ID = 3;
        public ObservableCollection<Oglas> NovoDodanaVozila { get; set; }
        public PocetnaPage()
        {
            InitializeComponent();
            NovoDodanaVozila = new ObservableCollection<Oglas>();
        }

        protected override void OnAppearing()
        {
            GetNovoDodanaVozila();
        }

        private async void GetNovoDodanaVozila()
        {
            var vozila = await APIService.GetOglase();
            if (vozila.Count() != NovoDodanaVozila.Count())
            {
                NovoDodanaVozila.Clear();

                foreach (var vozilo in vozila)
                {
                    NovoDodanaVozila.Add(vozilo);
                }
                CvVozila.ItemsSource = NovoDodanaVozila;
            }
        }

        private void CvVozila_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelection = e.CurrentSelection.FirstOrDefault() as Oglas;
            Navigation.PushModalAsync(new VoziloDetaljiPage(currentSelection.VoziloId));
        }

        private void TapMotocikli_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new VozilaListPage(Motocikli_ID));
        }

        private void TapAutomobili_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new VozilaListPage(Automobili_ID));
        }

        private void TapKamioni_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new VozilaListPage(TeretnaVozila_ID));
        }

        private void TapSearch_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PretragaPage());
        }
    }
}