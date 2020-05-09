using eVehicleDealership.Modeli;
using eVehicleDealership.Modeli.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVehicleDealership.WebAPI.Services
{
    public interface IVozilaService
    {
        IList<OglasDetaljiModel> Get(OglasSearchRequest request);
        Modeli.VoziloDetalji GetById(int id);
        IList<Modeli.VoziloPoKategoriji> GetByKategorija(int kategorijaId);
        IEnumerable<Modeli.VoziloSearch> Pretraga(string search);
        VoziloResponse Insert(Modeli.Vozilo vozilo);
        IEnumerable<Modeli.Oglas> GetOglase();
        IEnumerable<Modeli.MojOglas> GetMojeOglase(string userEmail);
        Oglas GetOglasByVozilo(int voziloId);
        VoziloResponse Update(int id, VoziloUpdateRequest request);
    }
}
