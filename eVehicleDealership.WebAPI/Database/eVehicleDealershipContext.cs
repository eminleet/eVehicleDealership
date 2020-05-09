using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVehicleDealership.WebAPI.Database
{
    public class eVehicleDealershipContext : DbContext
    {
        public eVehicleDealershipContext(DbContextOptions<eVehicleDealershipContext> options)
           : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Drzava> Drzave { get; set; }
        public virtual DbSet<Grad> Gradovi { get; set; }
        public virtual DbSet<Kategorija> Kategorije { get; set; }
        public virtual DbSet<Korisnik> Korisnici { get; set; }
        public virtual DbSet<KorisnikUloga> KorisniciUloge { get; set; }
        public virtual DbSet<Model> Modeli { get; set; }
        public virtual DbSet<Ocjena> Ocjene { get; set; }
        public virtual DbSet<Proizvodjac> Proizvodjaci { get; set; }
        public virtual DbSet<Uloga> Uloge { get; set; }
        public virtual DbSet<Vozilo> Vozila { get; set; }
        public virtual DbSet<SlikaVozila> SlikeVozila { get; set; }
    }
}
