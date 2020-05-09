using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eVehicleDealership.Modeli
{
    public class Kategorija
    {
        public int KategorijaId { get; set; }
        public string Naziv { get; set; }
        public object Vozila { get; set; }
    }
}
