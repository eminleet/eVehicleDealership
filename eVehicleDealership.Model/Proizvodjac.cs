using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace eVehicleDealership.Modeli
{
    public class Proizvodjac
    {
        public int ProizvodjacId { get; set; }
        public int DrzavaId { get; set; }
        public string Naziv { get; set; }
        public byte[] Logo { get; set; }
    }
}
