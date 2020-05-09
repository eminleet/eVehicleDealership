using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eVehicleDealership.WebAPI
{
    public class Drzava
    {
        public int DrzavaId { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Naziv { get; set; }
    }
}
