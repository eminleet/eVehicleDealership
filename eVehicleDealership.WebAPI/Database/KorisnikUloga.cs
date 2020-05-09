using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eVehicleDealership.WebAPI
{
    public class KorisnikUloga
    {
        public int KorisnikUlogaId { get; set; }
        public int KorisnikId { get; set; }
        public int UlogaId { get; set; }
        public DateTime DatumIzmjene { get; set; }

        public Korisnik Korisnik { get; set; }
        public Uloga Uloga { get; set; }
    }
}
