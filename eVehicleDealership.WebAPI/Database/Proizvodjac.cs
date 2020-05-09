using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace eVehicleDealership.WebAPI
{
    public class Proizvodjac
    {
        public int ProizvodjacId { get; set; }
        public int DrzavaId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Naziv { get; set; }

        public byte[] Logo { get; set; }

        public Drzava Drzava { get; set; }
    }
}
