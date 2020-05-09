using eVehicleDealership.Modeli;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class VoziloDetaljiPage : ContentPage
    {
        public ObservableCollection<SlikaVozilaModel> slikeVozila;
        private int _ukupnoSlika = 0;
        private string _brojTelefona;
        private string _email;
        private int _voziloId;
        public VoziloDetaljiPage(int voziloId)
        {
            InitializeComponent();
            slikeVozila = new ObservableCollection<SlikaVozilaModel>();
            _voziloId = voziloId;
            GetProsjecnaOcjena();

            GetDetaljeVozila(voziloId);
            GetRecommendedOglase(voziloId);
            GetUserRating(voziloId);
        }

        private async void GetUserRating(int voziloId)
        {
            var response = await APIService.GetOcjenaByVoziloAndKorisnik(_voziloId, Preferences.Get("korisnikId", 0));

            if (response != -1)
            {
                UserRating.Value = response;
            }
        }

        private async void GetRecommendedOglase(int voziloId)
        {
            Recommender recommender = new Recommender();
            var oglasi = await recommender.GetSlicneOglase(voziloId);
            if (oglasi.Count > 0)
            {
                CvPreporucenaVozila.IsVisible = true;
                CvPreporucenaVozila.ItemsSource = oglasi;
            }
        }

        private async void GetProsjecnaOcjena()
        {
            var ocjene = await APIService.GetOcjeneByVozilo(_voziloId);

            if (ocjene == null)
            {
                LblOcjena.Text = "Budite prvi koji će ocijeniti ovaj oglas!";
            }
            else
            {
                var prosjecnaOcjena = ocjene.Average(x => x.DataOcjena);
                Rating.Value = prosjecnaOcjena;
                LblOcjena.Text = $"Trenutna prosječna ocjena: {prosjecnaOcjena}";
            }
        }

        private async void GetDetaljeVozila(int id)
        {
            var vozilo = await APIService.GetDetaljiVozila(id);
            LblBoja.Text = vozilo.Boja;
            LblCijena.Text = vozilo.Cijena.ToString();
            LblGodiste.Text = vozilo.GodinaProizvodnje.ToString();
            LblKonjskihSnaga.Text = vozilo.KonjskihSnaga.ToString();
            LblKratkiOpis.Text = vozilo.Opis;
            LblLokacija.Text = vozilo.Lokacija;
            LblModel.Text = vozilo.Model;
            LblKubikaza.Text = vozilo.Kubikaza;
            LblProizvodjac.Text = vozilo.Proizvodjac;
            LblNaziv.Text = vozilo.Naziv;
            LblStanje.Text = vozilo.Stanje;
            LblTransmisija.Text = vozilo.Transmisija;
            _brojTelefona = vozilo.Telefon;
            _email = vozilo.Email;
            var images = await APIService.GetSlikeVozila(id);
            if (images != null)
            {
                _ukupnoSlika = images.Count;
                foreach (var item in images)
                {
                    slikeVozila.Add(item);
                }
            }
            CrvImages.ItemsSource = slikeVozila;

            var model = new SlikaKorisnikaModel
            {
                Slika = vozilo.SlikaKorisnika
            };

            if (vozilo.SlikaKorisnika != null && vozilo.SlikaKorisnika.Length > 0)
            {
                Stream stream = new MemoryStream(vozilo.SlikaKorisnika);
                ImgKontakt.Source = ImageSource.FromStream(() => stream);
            }
            else
            {
                ImgKontakt.Source = "userPlaceholder.png";
            }
        }

        private void CrvImages_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            if (e.FirstVisibleItemIndex <= _ukupnoSlika)
            {
                var brojac = e.FirstVisibleItemIndex + 1;
                LblBrojac.Text = brojac + " od " + _ukupnoSlika;
            }
        }

        private void BtnEmail_Clicked(object sender, EventArgs e)
        {
            var email = new EmailMessage("Upit u vezi oglasa", "Pozdrav, želim se dodatno raspitati o detaljima ovog vozila...", _email);
            Email.ComposeAsync(email);
        }

        private void BtnSms_Clicked(object sender, EventArgs e)
        {
            var sms = new SmsMessage("Pozdrav, želim se dodatno raspitati o detaljima ovog vozila ...", _brojTelefona);
            Sms.ComposeAsync(sms);
        }

        private void BtnPoziv_Clicked(object sender, EventArgs e)
        {
            PhoneDialer.Open(_brojTelefona);
        }

        private void BtnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void CvPreporucenaVozila_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelection = e.CurrentSelection.FirstOrDefault() as Oglas;
            Navigation.PushModalAsync(new VoziloDetaljiPage(currentSelection.VoziloId));
        }

        private async void UserRating_ValueChanged(object sender, Syncfusion.SfRating.XForms.ValueEventArgs e)
        {
            int ocjena = Convert.ToInt32(e.Value);
            var model = await APIService.SetOcjena(_voziloId, ocjena);
            UserRating.Value = ocjena;
            UserRating.IsVisible = false;

            LblUserRatingMessage.Text = "Uspješno ste ocijenili oglas.";
            Device.StartTimer(new TimeSpan(0, 0, 4), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    LblUserRatingMessage.IsVisible = false;
                    LblUserRatingMessage.Text = "";
                });
                return false;
            });

            Rating.Value = model.ProsjecnaOcjena;

            LblOcjena.Text = $"Trenutna prosječna ocjena: {model.ProsjecnaOcjena}";
        }

        private void BtnUserOcjena_Clicked(object sender, EventArgs e)
        {
            UserRating.IsVisible = !UserRating.IsVisible;
        }
    }
}