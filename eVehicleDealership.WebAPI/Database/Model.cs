using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eVehicleDealership.WebAPI
{
    public class Model
    {
        public int ModelId { get; set; }
        public int ProizvodjacId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Naziv { get; set; }

        public Proizvodjac Proizvodjac { get; set; }
    }
}
