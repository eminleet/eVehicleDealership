using System;
using System.Collections.Generic;
using System.Text;

namespace eVehicleDealership.Modeli
{
    public class VoziloDetalji
    {
        public int VoziloId { get; set; }
        public string Model { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public decimal Cijena { get; set; }
        public string Transmisija { get; set; }
        public string Gorivo { get; set; }
        public int GodinaProizvodnje { get; set; }
        public int KonjskihSnaga { get; set; }
        public string Boja { get; set; }
        public string Kubikaza { get; set; }
        public string Stanje { get; set; }
        public DateTime DatumPostavljanja { get; set; }
        public string Proizvodjac { get; set; }
        public string Lokacija { get; set; }
        public ICollection<SlikaVozilaModel> Slike = new List<SlikaVozilaModel>();
        public string Email { get; set; }
        public string Telefon { get; set; }
        public bool Istaknuto { get; set; }
        public string Korisnik { get; set; }
        public byte[] SlikaKorisnika { get; set; }
        public byte[] SlikaVozila { get; set; }
    }
}
