using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eVehicleDealership.WebAPI.Database
{
    public class SlikaVozila
    {
        public int SlikaVozilaId { get; set; }
        public int VoziloId { get; set; }
        public Vozilo Vozilo { get; set; }
        public byte[] Slika { get; set; }
    }
}
