using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eVehicleDealership.Modeli
{
    public class SlikaVozilaModel
    {
        public int VoziloId { get; set; }

        public byte[] Slika { get; set; }
    }
}
