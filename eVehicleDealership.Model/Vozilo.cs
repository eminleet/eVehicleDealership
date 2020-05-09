using System;
using System.Collections.Generic;
using System.Text;

namespace eVehicleDealership.Modeli
{
    public class Vozilo
    {
        public int ModelId { get; set; }
        public string Opis { get; set; }
        public string Naziv { get; set; }
        public decimal Cijena { get; set; }
        public string Transmisija { get; set; }
        public string Gorivo { get; set; }
        public int GodinaProizvodnje { get; set; }
        public int KonjskihSnaga { get; set; }
        public string Boja { get; set; }
        public string Kubikaza { get; set; }
        public string Stanje { get; set; }
        public int GradId { get; set; }
        public int KorisnikId { get; set; }
        public int KategorijaId { get; set; }
    }
}
