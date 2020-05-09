using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eVehicleDealership.WebAPI
{
    public class Ocjena
    {
        public int OcjenaId { get; set; }
        public int VoziloId { get; set; }
        public int KorisnikId { get; set; }
        [Required]
        public int DataOcjena { get; set; }

        public Vozilo Vozilo { get; set; }
        public Korisnik Korisnik { get; set; }
    }
}
