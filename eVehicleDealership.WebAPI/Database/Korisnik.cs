using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eVehicleDealership.WebAPI
{
    public class Korisnik
    {
        public int KorisnikId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Ime { get; set; }
        [Required]
        [MaxLength(50)]
        public string Prezime { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public string Telefon { get; set; }
        public byte[] Slika { get; set; }

        public ICollection<KorisnikUloga> KorisnikUloga { get; set; }
    }
}
