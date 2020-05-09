using System;
using System.Collections.Generic;
using System.Text;

namespace eVehicleDealership.Modeli
{
    public class Oglas
    {
        public int VoziloId { get; set; }
        public string Naziv { get; set; }
        public decimal Cijena { get; set; }
        public string Model { get; set; }
        public string Proizvodjac { get; set; }
        public bool Istaknuto { get; set; }
        public byte[] Slika { get; set; }
    }
}
