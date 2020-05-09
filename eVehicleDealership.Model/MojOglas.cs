using System;
using System.Collections.Generic;
using System.Text;

namespace eVehicleDealership.Modeli
{
    public class MojOglas
    {
        public int VoziloId { get; set; }
        public string Naziv { get; set; }
        public decimal Cijena { get; set; }
        public string Model { get; set; }
        public string Lokacija { get; set; }
        public bool Istaknuto { get; set; }
        public string Proizvodjac { get; set; }
        public DateTime DatumPostavljanja { get; set; }
        public byte[] Slika { get; set; }
        public string IstaknutOglas => Istaknuto ? "Istaknuto" : "Besplatan oglas";
        public string DatumPostavljanjaFormat => DatumPostavljanja.ToString("y");
    }
}
