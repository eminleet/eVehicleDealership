using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eVehicleDealership.Modeli
{
    public class Model
    {
        public int ModelId { get; set; }
        public int ProizvodjacId { get; set; }
        public string Proizvodjac { get; set; }
        public string Naziv { get; set; }
    }
}
