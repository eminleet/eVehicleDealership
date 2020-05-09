using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eVehicleDealership.WebAPI
{
    public class Kategorija
    {
        public int KategorijaId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Naziv { get; set; }

        public ICollection<Vozilo> Vozila { get; set; }
    }
}
