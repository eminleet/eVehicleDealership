using System;
using System.Collections.Generic;
using System.Text;

namespace eVehicleDealership.Modeli
{
    public class OglasDetaljiModel
    {
        public int VoziloId { get; set; }
        public string Naziv { get; set; }
        public string Cijena { get; set; }
        public string Model { get; set; }
        public string Kategorija { get; set; }
        public string Lokacija { get; set; }
        public string Proizvodjac { get; set; }
        public bool Istaknuto { get; set; }
        public DateTime DatumPostavljanja { get; set; }
        public string Korisnik { get; set; }
        public string IstaknutOglas => Istaknuto ? "Istaknuto" : "Besplatan oglas";
        public string DatumPostavljanjaFormat => DatumPostavljanja.ToString("y");
    }
}
