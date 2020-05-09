using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eVehicleDealership.Modeli
{
    public class Grad
    {
        public int GradId { get; set; }
        public int DrzavaId { get; set; }
        public string Naziv { get; set; }
    }
}
