using System;
using System.Collections.Generic;
using System.Text;

namespace eVehicleDealership.Modeli.Requests
{
    public class OglasSearchRequest
    {
        public string Korisnik { get; set; }
        public string Naslov { get; set; }
        public string Proizvodjac { get; set; }
        public string Kategorija { get; set; }
    }
}
