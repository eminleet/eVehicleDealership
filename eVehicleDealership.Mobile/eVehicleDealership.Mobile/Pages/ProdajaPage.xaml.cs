using eVehicleDealership.Modeli;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eVehicleDealership.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProdajaPage : ContentPage
    {
        public ObservableCollection<Modeli.Kategorija> KategorijeCollection = new ObservableCollection<Kategorija>();
        public ObservableCollection<Modeli.Drzava> DrzaveCollection = new ObservableCollection<Drzava>();
        public ObservableCollection<Modeli.Grad> GradoviCollection = new ObservableCollection<Grad>();
        public ObservableCollection<Modeli.Proizvodjac> ProizvodjaciCollection = new ObservableCollection<Proizvodjac>();
        public ObservableCollection<Modeli.Model> ModeliCollection = new ObservableCollection<Model>();
        public ObservableCollection<int> GodineCollection = new ObservableCollection<int>();
        public ObservableCollection<string> KubikazeCollection = new ObservableCollection<string>();
        public ObservableCollection<string> BojeCollection = new ObservableCollection<string>();
        public ObservableCollection<string> TransmisijeCollection = new ObservableCollection<string>();
        public ObservableCollection<string> GorivaCollection = new ObservableCollection<string>();
        private int kategorijaId;
        private int gradId;
        private int godiste;
        private string kubikaza;
        private string boja;
        private string transmisija;
        private string gorivo;
        private string stanje = "Korišteno";
        private int modelId;
        public ProdajaPage()
        {
            InitializeComponent();
            GetProizvodjace();
            GetKategorije();
            GetDrzave();
            GetGodine();
            GetKubikaze();
            GetBoje();
            GetTransmisije();
            GetGoriva();
        }

        private async void GetProizvodjace()
        {
            var proizvodjaci = await APIService.GetProizvodjace();
            proizvodjaci = proizvodjaci.OrderBy(x => x.ProizvodjacId).ToList();
            foreach (var item in proizvodjaci)
            {
                ProizvodjaciCollection.Add(item);
            }
            PickerProizvodjac.ItemsSource = ProizvodjaciCollection;
        }

        private void GetGoriva()
        {
            var goriva = Modeli.GorivoModel.Goriva;
            foreach (var item in goriva)
            {
                GorivaCollection.Add(item);
            }
            PickerGorivo.ItemsSource = GorivaCollection;
        }

        private void GetTransmisije()
        {
            var transmisije = Modeli.Transmisija.Transmisije;
            foreach (var item in transmisije)
            {
                TransmisijeCollection.Add(item);
            }
            PickerTransmisija.ItemsSource = TransmisijeCollection;
        }

        private void GetBoje()
        {
            var boje = Modeli.BojaModel.Boje;
            foreach (var item in boje)
            {
                BojeCollection.Add(item);
            }
            PickerBoja.ItemsSource = BojeCollection;
        }

        private void GetKubikaze()
        {
            var kubikaze = Modeli.KubikazaModel.GetKubikaze();
            foreach (var item in kubikaze)
            {
                KubikazeCollection.Add(item);
            }
            PickerKubikaza.ItemsSource = KubikazeCollection;
        }

        private void GetGodine()
        {
            var godine = Modeli.GodisteModel.GetGodine();
            foreach (var item in godine)
            {
                GodineCollection.Add(item);
            }
            PickerGodiste.ItemsSource = GodineCollection;
        }

        private async void GetDrzave()
        {
            var drzave = await APIService.GetDrzave();
            foreach (var item in drzave)
            {
                DrzaveCollection.Add(item);
            }
            PickerDrzava.ItemsSource = DrzaveCollection;
        }

        private async void GetKategorije()
        {
            var kategorije = await APIService.GetKategorije();
            foreach (var item in kategorije)
            {
                KategorijeCollection.Add(item);
            }
            PickerKategorija.ItemsSource = KategorijeCollection;
        }

        private async void BtnSell_Clicked(object sender, EventArgs e)
        {
            var vozilo = new Modeli.Vozilo();
            vozilo.Naziv = EntNaslov.Text;
            if(int.TryParse(EntKonjskihSnaga.Text, out int konjskihSnaga))
            {
                vozilo.KonjskihSnaga = konjskihSnaga;
            }
            if (int.TryParse(EntCijena.Text, out int cijena))
            {
                vozilo.Cijena = cijena;
            }
            vozilo.KorisnikId = Preferences.Get("korisnikId", 0);
            vozilo.KategorijaId = kategorijaId;
            vozilo.Stanje = stanje;
            vozilo.GradId = gradId;
            vozilo.GodinaProizvodnje = godiste;
            vozilo.Boja = boja;
            vozilo.Gorivo = gorivo;
            vozilo.Kubikaza = kubikaza;
            vozilo.Transmisija = transmisija;
            vozilo.ModelId = modelId;
            vozilo.Opis = KratkiOpis.Text;

            var response = await APIService.DodajVozilo(vozilo);
            if (response == null) return;
            var voziloId = response.VoziloId;

            await Navigation.PushAsync(new DodajSlikuVozilaPage(voziloId));
        }

        private void PickerKategorija_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            var selectedKategorija = (Modeli.Kategorija)picker.SelectedItem;
            kategorijaId = selectedKategorija.KategorijaId;
        }

        private void TapKoristeno_Tapped(object sender, EventArgs e)
        {
            stanje = "Korišteno";
            FrameKoristeno.BackgroundColor = Color.FromHex("#0779E4");
            LblKoristeno.TextColor = Color.White;
            FrameNovo.BackgroundColor = Color.White;
            LblNovo.TextColor = Color.Black;
        }

        private void TapNovo_Tapped(object sender, EventArgs e)
        {
            stanje = "Novo";
            FrameNovo.BackgroundColor = Color.FromHex("#0779E4");
            LblNovo.TextColor = Color.White;
            FrameKoristeno.BackgroundColor = Color.White;
            LblKoristeno.TextColor = Color.Black;
        }

        private async void PickerDrzava_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            var selectedDrzava = (Modeli.Drzava)picker.SelectedItem;
            var gradovi = await APIService.GetGradovePoDrzavi(selectedDrzava.DrzavaId);
            GradoviCollection.Clear();
            foreach (var item in gradovi)
            {
                GradoviCollection.Add(item);
            }
            PickerGrad.ItemsSource = GradoviCollection;
            LblGrad.IsVisible = true;
            PickerGrad.IsVisible = true;
        }

        private void PickerGrad_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            var selectedKategorija = (Modeli.Grad)picker.SelectedItem;
            gradId = selectedKategorija.GradId;
        }

        private void PickerGodiste_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            var selectedGodiste = (int)picker.SelectedItem;
            godiste = selectedGodiste;
        }

        private void PickerKubikaza_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            kubikaza = (string)picker.SelectedItem;
        }

        private void PickerBoja_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            boja = (string)picker.SelectedItem;
        }

        private void PickerTransmisija_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            transmisija = (string)picker.SelectedItem;
        }

        private void PickerGorivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            gorivo = (string)picker.SelectedItem;
        }

        private async void PickerProizvodjac_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            var selectedProizvodjac = (Modeli.Proizvodjac)picker.SelectedItem;
            var modeli = await APIService.GetModelePoProizvodjacu(selectedProizvodjac.ProizvodjacId);
            ModeliCollection.Clear();
            foreach (var item in modeli)
            {
                ModeliCollection.Add(item);
            }
            PickerModel.ItemsSource = ModeliCollection;
        }

        private void PickerModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            var selectedModel = (Modeli.Model)picker.SelectedItem;
            modelId = selectedModel.ModelId;
        }
    }
}