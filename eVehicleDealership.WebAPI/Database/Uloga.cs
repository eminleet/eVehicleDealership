using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eVehicleDealership.WebAPI
{
    public class Uloga
    {
        public int UlogaId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Naziv { get; set; }

        public ICollection<KorisnikUloga> KorisnikUloga { get; set; }
    }
}
