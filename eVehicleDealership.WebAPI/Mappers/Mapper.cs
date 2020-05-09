using AutoMapper;
using eVehicleDealership.Modeli.Requests;
using eVehicleDealership.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVehicleDealership.WebAPI.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Korisnik, Modeli.Korisnik>();
            CreateMap<Vozilo, Modeli.Vozilo>();
            CreateMap<Korisnik, KorisnikInsertRequest>().ReverseMap();
            CreateMap<Model, ModelInsertRequest>().ReverseMap();
            CreateMap<Drzava, Modeli.Drzava>();
            CreateMap<Grad, Modeli.Grad>();
            CreateMap<Proizvodjac, Modeli.Proizvodjac>();
            CreateMap<Uloga, Modeli.Uloga>();
            CreateMap<Model, Modeli.Model>();
            CreateMap<KorisnikUloga, Modeli.KorisnikUloga>().ReverseMap();
            CreateMap<KorisnikUloga, Modeli.Uloga>().ReverseMap();
            CreateMap<Ocjena, Modeli.OcjenaModel>().ReverseMap();
            CreateMap<Kategorija, Modeli.Kategorija>();
            CreateMap<SlikaVozila, Modeli.SlikaVozilaModel>().ReverseMap();
            CreateMap<Vozilo, Modeli.VoziloDetalji>().ReverseMap();
            CreateMap<Vozilo, Modeli.Vozilo>().ReverseMap();
            CreateMap<Proizvodjac, ProizvodjacUpsertRequest>().ReverseMap();
        }
    }
}
