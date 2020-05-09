using eVehicleDealership.WebAPI.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eVehicleDealership.WebAPI
{
    public class Vozilo
    {
        public int VoziloId { get; set; }
        public int ModelId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Cijena { get; set; }
        [Required]
        public string Transmisija { get; set; }
        [Required]
        public string Gorivo { get; set; }
        [Required]
        public int GodinaProizvodnje { get; set; }
        [Required]
        public int KonjskihSnaga { get; set; }
        [Required]
        public string Kubikaza { get; set; }
        [Required]
        public string Boja { get; set; }
        [Required]
        public string Stanje { get; set; }
        public bool Istaknuto { get; set; }
        public DateTime DatumPostavljanja { get; set; }

        [Display(Name = "Lokacija")]
        public int GradId { get; set; }

        public int KorisnikId { get; set; }
        public int KategorijaId { get; set; }

        public Model Model { get; set; }
        public Grad Grad { get; set; }
        public Korisnik Korisnik { get; set; }
        public Kategorija Kategorija { get; set; }

        public ICollection<SlikaVozila> SlikeVozila { get; set; }
    }
}
