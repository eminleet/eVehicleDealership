using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eVehicleDealership.Modeli.Requests
{
    public class KorisnikInsertRequest
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public byte[] Slika { get; set; }
        public List<int> Uloge { get; set; }
    }
}
