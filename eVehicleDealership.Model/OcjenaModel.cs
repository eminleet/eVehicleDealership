using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eVehicleDealership.Modeli
{
    public class OcjenaModel
    {
        public int VoziloId { get; set; }
        public int KorisnikId { get; set; }
        public int DataOcjena { get; set; }
        public double ProsjecnaOcjena { get; set; }
    }
}
