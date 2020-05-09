using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eVehicleDealership.Modeli.Requests
{
    public class ProizvodjacUpsertRequest
    {
        [Required]
        public int DrzavaId { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public byte[] Logo { get; set; }
    }
}
