using AutoMapper;
using eVehicleDealership.Modeli;
using eVehicleDealership.Modeli.Requests;
using eVehicleDealership.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVehicleDealership.WebAPI.Services
{
    public class VozilaService : IVozilaService
    {
        private readonly eVehicleDealershipContext _context;
        private readonly IMapper _mapper;

        public VozilaService(eVehicleDealershipContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<OglasDetaljiModel> Get(OglasSearchRequest request)
        {
            var result = new List<OglasDetaljiModel>();

            var query = _context.Vozila.Include(x => x.Korisnik)
                                       .Include(x => x.Kategorija)
                                       .Include(x => x.Model.Proizvodjac)
                                       .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Korisnik))
            {
                var search = ToUpper(request.Korisnik);
                query = query.Where(x => x.Korisnik.Ime.StartsWith(search) || x.Korisnik.Prezime.StartsWith(search));
            }
            if (!string.IsNullOrWhiteSpace(request?.Kategorija))
            {
                var search = ToUpper(request.Kategorija);
                query = query.Where(x => x.Kategorija.Naziv.StartsWith(search));
            }
            if (!string.IsNullOrWhiteSpace(request?.Naslov))
            {
                var search = ToUpper(request.Naslov);
                query = query.Where(x => x.Naziv.StartsWith(search));
            }
            if (!string.IsNullOrWhiteSpace(request?.Proizvodjac))
            {
                var search = ToUpper(request.Proizvodjac);
                query = query.Where(x => x.Model.Proizvodjac.Naziv.StartsWith(search));
            }

            foreach (var vozilo in query.Include(x => x.Grad)
                                        .Include(x => x.Model)
                                        .Include(x => x.Grad.Drzava)
                                        .ToList())
            {
                var novo = new OglasDetaljiModel
                {
                    VoziloId = vozilo.VoziloId,
                    Cijena = "€" + vozilo.Cijena.ToString(),
                    DatumPostavljanja = vozilo.DatumPostavljanja,
                    Lokacija = vozilo.Grad.Naziv + ", " + vozilo.Grad.Drzava.Naziv,
                    Kategorija = vozilo.Kategorija.Naziv,
                    Model = vozilo.Model.Naziv,
                    Korisnik = vozilo.Korisnik.Ime + " " + vozilo.Korisnik.Prezime,
                    Naziv = vozilo.Naziv,
                    Istaknuto = vozilo.Istaknuto,
                    Proizvodjac = vozilo.Model.Proizvodjac.Naziv
                };
                result.Add(novo);
            }

            return result;
        }

        public VoziloDetalji GetById(int id)
        {
            var foundVehicle = _context.Vozila.Include(x => x.Korisnik)
                                              .Include(x => x.Grad)
                                              .Include(x => x.Grad.Drzava)
                                              .Include(x => x.Model)
                                              .Include(x => x.Model.Proizvodjac)
                                              .SingleOrDefault(x => x.VoziloId == id);
            if (foundVehicle == null)
            {
                return null;
            }

            var result = new VoziloDetalji
            {
                VoziloId = foundVehicle.VoziloId,
                Boja = foundVehicle.Boja,
                Cijena = foundVehicle.Cijena,
                DatumPostavljanja = foundVehicle.DatumPostavljanja,
                Email = foundVehicle.Korisnik.Email,
                GodinaProizvodnje = foundVehicle.GodinaProizvodnje,
                Gorivo = foundVehicle.Gorivo,
                KonjskihSnaga = foundVehicle.KonjskihSnaga,
                Lokacija = foundVehicle.Grad.Naziv + ", " + foundVehicle.Grad.Drzava.Naziv,
                Model = foundVehicle.Model.Naziv,
                Naziv = foundVehicle.Naziv,
                Istaknuto = foundVehicle.Istaknuto,
                Opis = foundVehicle.Opis,
                Kubikaza = foundVehicle.Kubikaza,
                Korisnik = foundVehicle.Korisnik.Ime + " " + foundVehicle.Korisnik.Prezime,
                Stanje = foundVehicle.Stanje,
                Telefon = foundVehicle.Korisnik.Telefon,
                Transmisija = foundVehicle.Transmisija,
                Proizvodjac = foundVehicle.Model.Proizvodjac.Naziv,
            };

            if (_context.SlikeVozila.Any(x => x.VoziloId == foundVehicle.VoziloId))
            {
                result.SlikaVozila = _context.SlikeVozila.FirstOrDefault(x => x.VoziloId == foundVehicle.VoziloId).Slika;
                foreach (var slika in _context.SlikeVozila.Where(x => x.VoziloId == foundVehicle.VoziloId)
                                                          .ToList())
                {
                    result.Slike.Add(new SlikaVozilaModel
                    {
                        VoziloId = slika.VoziloId,
                        Slika = slika.Slika
                    });
                }
            }
            if (foundVehicle.Korisnik.Slika != null && foundVehicle.Korisnik.Slika.Length > 0)
            {
                result.SlikaKorisnika = foundVehicle.Korisnik.Slika;
            }

            return result;
        }

        public IList<VoziloPoKategoriji> GetByKategorija(int kategorijaId)
        {
            var result = new List<VoziloPoKategoriji>();

            foreach (var vozilo in _context.Vozila.Include(x => x.Grad)
                                        .Include(x => x.Model)
                                        .Include(x => x.Grad.Drzava)
                                        .Include(x => x.Model.Proizvodjac)
                                        .Where(x => x.KategorijaId == kategorijaId)
                                        .ToList())
            {
                var novo = new VoziloPoKategoriji
                {
                    VoziloId = vozilo.VoziloId,
                    Cijena = vozilo.Cijena,
                    DatumPostavljanja = vozilo.DatumPostavljanja,
                    Lokacija = vozilo.Grad.Naziv + ", " + vozilo.Grad.Drzava.Naziv,
                    Model = vozilo.Model.Naziv,
                    Naziv = vozilo.Naziv,
                    Istaknuto = vozilo.Istaknuto,
                    Proizvodjac = vozilo.Model.Proizvodjac.Naziv
                };

                if (_context.SlikeVozila.Any(x => x.VoziloId == vozilo.VoziloId))
                {
                    novo.Slika = _context.SlikeVozila.FirstOrDefault(x => x.VoziloId == vozilo.VoziloId).Slika;
                }
                result.Add(novo);
            }

            return result.OrderByDescending(x => x.Istaknuto).ToList();
        }

        public IEnumerable<MojOglas> GetMojeOglase(string userEmail)
        {
            var user = _context.Korisnici.SingleOrDefault(u => u.Email == userEmail);

            if (user == null) return null;

            var result = new List<MojOglas>();

            foreach (var vozilo in _context.Vozila.Include(x => x.Model)
                                                  .Include(x => x.Model.Proizvodjac)
                                                  .Include(x => x.Grad)
                                                  .Where(x => x.KorisnikId == user.KorisnikId)
                                                  .OrderByDescending(x => x.DatumPostavljanja)
                                                  .ToList())
            {
                var oglas = new MojOglas
                {
                    VoziloId = vozilo.VoziloId,
                    Cijena = vozilo.Cijena,
                    Model = vozilo.Model.Naziv,
                    Proizvodjac = vozilo.Model.Proizvodjac.Naziv,
                    Naziv = vozilo.Naziv,
                    Istaknuto = vozilo.Istaknuto,
                    DatumPostavljanja = vozilo.DatumPostavljanja,
                    Lokacija = vozilo.Grad.Naziv
                };
                if (_context.SlikeVozila.Any(x => x.VoziloId == vozilo.VoziloId))
                {
                    oglas.Slika = _context.SlikeVozila.FirstOrDefault(x => x.VoziloId == vozilo.VoziloId).Slika;
                }
                result.Add(oglas);
            }

            return result.OrderByDescending(x => x.Istaknuto).ToList();
        }

        public Oglas GetOglasByVozilo(int voziloId)
        {
            var vozilo = _context.Vozila.Include(x => x.Model)
                           .Include(x => x.Model.Proizvodjac)
                           .SingleOrDefault(x => x.VoziloId == voziloId);
            var oglas = new Oglas
            {
                VoziloId = vozilo.VoziloId,
                Cijena = vozilo.Cijena,
                Model = vozilo.Model.Naziv,
                Proizvodjac = vozilo.Model.Proizvodjac.Naziv,
                Naziv = vozilo.Naziv,
                Istaknuto = vozilo.Istaknuto
            };
            if (_context.SlikeVozila.Any(x => x.VoziloId == vozilo.VoziloId))
            {
                oglas.Slika = _context.SlikeVozila.FirstOrDefault(x => x.VoziloId == vozilo.VoziloId).Slika;
            }

            return oglas;
        }

        public IEnumerable<Oglas> GetOglase()
        {
            var result = new List<Oglas>();

            foreach (var vozilo in _context.Vozila.Include(x => x.Model)
                                                  .Include(x => x.Model.Proizvodjac)
                                                  .OrderByDescending(x => x.DatumPostavljanja)
                                                  .ToList())
            {
                var oglas = new Oglas
                {
                    VoziloId = vozilo.VoziloId,
                    Cijena = vozilo.Cijena,
                    Model = vozilo.Model.Naziv,
                    Proizvodjac = vozilo.Model.Proizvodjac.Naziv,
                    Naziv = vozilo.Naziv,
                    Istaknuto = vozilo.Istaknuto
                };
                if (_context.SlikeVozila.Any(x => x.VoziloId == vozilo.VoziloId))
                {
                    oglas.Slika = _context.SlikeVozila.FirstOrDefault(x => x.VoziloId == vozilo.VoziloId).Slika;
                }
                result.Add(oglas);
            }

            return result;
        }

        public VoziloResponse Insert(Modeli.Vozilo vozilo)
        {
            try
            {
                var entity = new Vozilo
                {
                    Boja = vozilo.Boja,
                    Cijena = vozilo.Cijena,
                    DatumPostavljanja = DateTime.Now,
                    GodinaProizvodnje = vozilo.GodinaProizvodnje,
                    Gorivo = vozilo.Gorivo,
                    GradId = vozilo.GradId,
                    KategorijaId = vozilo.KategorijaId,
                    KonjskihSnaga = vozilo.KonjskihSnaga,
                    KorisnikId = vozilo.KorisnikId,
                    Kubikaza = vozilo.Kubikaza,
                    ModelId = vozilo.ModelId,
                    Opis = vozilo.Opis,
                    Stanje = vozilo.Stanje,
                    Transmisija = vozilo.Transmisija,
                };
                if (string.IsNullOrWhiteSpace(vozilo.Naziv))
                {
                    var model = _context.Modeli.SingleOrDefault(x => x.ModelId == vozilo.ModelId);
                    var proizvodjac = _context.Proizvodjaci.SingleOrDefault(x => x.ProizvodjacId == model.ProizvodjacId);
                    entity.Naziv = proizvodjac.Naziv + " " + model.Naziv;
                }
                else
                {
                    entity.Naziv = char.ToUpper(vozilo.Naziv[0]) + vozilo.Naziv.Substring(1);
                }

                _context.Vozila.Add(entity);
                _context.SaveChanges();

                return new VoziloResponse { Status = true, Poruka = "Vozilo uspješno dodano!", VoziloId = entity.VoziloId };
            }
            catch (Exception ex)
            {
                return new VoziloResponse { Status = false, Poruka = ex.Message };
            }
        }

        public IEnumerable<VoziloSearch> Pretraga(string search)
        {
            if (search.Length == 1)
                search = search.ToUpper();
            else
                search = char.ToUpper(search[0]) + search.Substring(1);

            var result = new List<VoziloSearch>();

            var vozilaInDb = _context.Vozila.Include(x => x.Model)
                                            .Include(x => x.Model.Proizvodjac)
                                            .Where(x => x.Naziv.StartsWith(search) || x.Model.Proizvodjac.Naziv.StartsWith(search))
                                            .ToList();

            foreach (var vozilo in vozilaInDb)
            {
                result.Add(new VoziloSearch
                {
                    VoziloId = vozilo.VoziloId,
                    Model = vozilo.Model.Naziv,
                    Naziv = vozilo.Naziv,
                    Proizvodjac = vozilo.Model.Proizvodjac.Naziv
                });
            }

            if (result.Count > 15)
                return result.Take(15);

            return result;
        }


        public string ToUpper(string search)
        {
            if (search.Length == 1)
                return search.ToUpper();
            else
                return char.ToUpper(search[0]) + search.Substring(1);
        }

        public VoziloResponse Update(int id, VoziloUpdateRequest request)
        {
            try
            {
                var entity = _context.Vozila.FirstOrDefault(x => x.VoziloId == id);
                entity.Istaknuto = request.Istaknuto;

                _context.SaveChanges();
                return new VoziloResponse { Status = true, Poruka = "Oglas istaknut!", VoziloId = entity.VoziloId };
            }
            catch (Exception ex)
            {
                return new VoziloResponse { Status = false, Poruka = ex.Message };
            }
        }
    }
}