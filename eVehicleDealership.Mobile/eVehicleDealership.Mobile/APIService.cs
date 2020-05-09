using eVehicleDealership.Modeli;
using eVehicleDealership.Modeli.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace eVehicleDealership.Mobile
{
    public static class APIService
    {
#if DEBUG
        public readonly static string _apiUrl = "http://10.0.2.2:8080/api";
#endif
#if RELEASE
        public readonly static string _apiUrl = "https://mywebsite.azure.com/api/";
#endif

        public static async Task<bool> RegisterUser(string ime, string prezime, string email, string telefon, string password, string passwordConfirmation)
        {
            var registerModel = new RegisterModel
            {
                Ime = ime,
                Prezime = prezime,
                Email = email,
                Telefon = telefon,
                Password = password,
                PasswordConfirmation = passwordConfirmation
            };

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(registerModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"{_apiUrl}/Korisnici/Register", content);
            if (!response.IsSuccessStatusCode) return false;
            return true;
        }

        public static async Task<bool> Login(string email, string password)
        {
            var loginModel = new LoginModel
            {
                Email = email,
                Password = password
            };

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(loginModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"{_apiUrl}/Korisnici/Login", content);
            if (!response.IsSuccessStatusCode) return false;
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Modeli.Korisnik>(jsonResult);
            Preferences.Set("access_token", result.Token);
            Preferences.Set("korisnikId", result.KorisnikId);
            Preferences.Set("token_expiration_time", result.Token_Expiration_Time);
            return true;
        }

        public static async Task<bool> ChangePassword(string oldPassword, string newPassword, string passwordConfirmation)
        {
            var changePasswordModel = new Modeli.ChangePasswordModel
            {
                OldPassword = oldPassword,
                NewPassword = newPassword,
                PasswordConfirmation = passwordConfirmation
            };

            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(changePasswordModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.PostAsync($"{_apiUrl}/Korisnici/ChangePassword", content);
            if (!response.IsSuccessStatusCode) return false;
            return true;
        }

        public static async Task<OcjenaModel> SetOcjena(int voziloId, int ocjena)
        {
            var ocjenaModel = new Modeli.OcjenaModel
            {
                VoziloId = voziloId,
                KorisnikId = Preferences.Get("korisnikId", 0),
                DataOcjena = ocjena
            };

            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(ocjenaModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.PostAsync($"{_apiUrl}/Ocjene", content).Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<OcjenaModel>(response);
        }

        public static async Task<bool> ChangePhoneNumber(string phoneNumber)
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            var content = new StringContent($"PhoneNumber={phoneNumber}", Encoding.UTF8, "application/x-www-form-urlencoded");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.PostAsync($"{_apiUrl}/Korisnici/ChangePhoneNumber", content);
            if (!response.IsSuccessStatusCode) return false;
            return true;
        }

        public static async Task<List<OcjenaModel>> GetOcjeneByVozilo(int voziloId)
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/Ocjene/GetOcjeneByVozilo/{voziloId}");
            return JsonConvert.DeserializeObject<List<OcjenaModel>>(response);
        }

        public static async Task<int> GetOcjenaByVoziloAndKorisnik(int voziloId, int korisnikId)
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/Ocjene/GetOcjenaByVoziloAndKorisnik/{voziloId}/{korisnikId}");
            return JsonConvert.DeserializeObject<int>(response);
        }

        public static async Task<Modeli.Oglas> GetOglasByVozilo(int voziloId)
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/Vozila/GetOglasByVozilo/{voziloId}");
            return JsonConvert.DeserializeObject<Modeli.Oglas>(response);
        }

        public static async Task<string> GetPhoneNumber()
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/Korisnici/GetPhoneNumber");
            return response;
        }

        public static async Task<bool> ChangeProfilePicture(byte[] imageArray)
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(imageArray);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.PostAsync($"{_apiUrl}/Korisnici/ChangeProfilePicture", content);
            if (!response.IsSuccessStatusCode) return false;
            return true;
        }

        public static async Task<ProfilePictureModel> GetProfilePicture()
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/Korisnici/GetProfilePicture");
            return JsonConvert.DeserializeObject<ProfilePictureModel>(response);
        }

        public static async Task<List<Modeli.Kategorija>> GetKategorije()
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/Kategorije");
            return JsonConvert.DeserializeObject<List<Modeli.Kategorija>>(response);
        }

        public static async Task<List<Modeli.Drzava>> GetDrzave()
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/Drzave");
            return JsonConvert.DeserializeObject<List<Modeli.Drzava>>(response);
        }

        public static async Task<List<Modeli.Grad>> GetGradovePoDrzavi(int drzavaId)
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/Gradovi/GetByDrzava/{drzavaId}");
            return JsonConvert.DeserializeObject<List<Modeli.Grad>>(response);
        }

        public static async Task<List<Modeli.Proizvodjac>> GetProizvodjace()
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/Proizvodjaci");
            return JsonConvert.DeserializeObject<List<Modeli.Proizvodjac>>(response);
        }

        public static async Task<List<Modeli.Model>> GetModelePoProizvodjacu(int proizvodjacId)
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/Modeli?ProizvodjacId={proizvodjacId}");
            return JsonConvert.DeserializeObject<List<Modeli.Model>>(response);
        }

        public static async Task<bool> DodajSlikuVozila(int voziloId, byte[] imageArray)
        {
            var voziloSlika = new SlikaVozilaModel
            {
                VoziloId = voziloId,
                Slika = imageArray
            };

            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(voziloSlika);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.PostAsync($"{_apiUrl}/SlikeVozila", content);
            if (!response.IsSuccessStatusCode) return false;
            return true;
        }

        public static async Task<VoziloDetalji> GetDetaljiVozila(int id)
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/Vozila/{id}");
            return JsonConvert.DeserializeObject<VoziloDetalji>(response);
        }

        public static async Task<List<VoziloPoKategoriji>> GetVozilaPoKategoriji(int kategorijaId)
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/Vozila/GetByKategorija/{kategorijaId}");
            return JsonConvert.DeserializeObject<List<VoziloPoKategoriji>>(response);
        }

        public static async Task<List<SlikaVozilaModel>> GetSlikeVozila(int voziloId)
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/SlikeVozila/GetByVozilo/{voziloId}");
            return JsonConvert.DeserializeObject<List<SlikaVozilaModel>>(response);
        }

        public static async Task<List<VoziloSearch>> PretragaVozila(string search)
        {
            await TokenValidator.CheckTokenValidity();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
                var response = await httpClient.GetStringAsync($"{_apiUrl}/Vozila/Pretraga/{search}");
                return JsonConvert.DeserializeObject<List<VoziloSearch>>(response);
            }
            return new List<VoziloSearch>{
                new VoziloSearch { VoziloId = -1 }
            };
        }

        public static async Task<VoziloResponse> DodajVozilo(Modeli.Vozilo vozilo)
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(vozilo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.PostAsync($"{_apiUrl}/Vozila", content);
            var jsonResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<VoziloResponse>(jsonResult);
        }

        public static async Task<List<Modeli.Oglas>> GetOglase()
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/Vozila/GetOglase");
            return JsonConvert.DeserializeObject<List<Modeli.Oglas>>(response);
        }

        public static async Task<List<Modeli.MojOglas>> GetMojeOglase()
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("access_token", string.Empty));
            var response = await httpClient.GetStringAsync($"{_apiUrl}/Vozila/MojiOglasi");
            return JsonConvert.DeserializeObject<List<Modeli.MojOglas>>(response);
        }
    }

    public static class TokenValidator
    {
        public static async Task CheckTokenValidity()
        {
            var expirationTime = Preferences.Get("token_expiration_time", DateTime.Now);
            if (DateTime.Compare(expirationTime, DateTime.Now) < 0)
            {
                var userEmail = Preferences.Get("userEmail", string.Empty);
                var userPassword = Preferences.Get("userPassword", string.Empty);
                await APIService.Login(userEmail, userPassword);
            }
        }
    }
}