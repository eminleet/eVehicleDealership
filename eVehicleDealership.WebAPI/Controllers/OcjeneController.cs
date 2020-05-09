using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eVehicleDealership.Modeli;
using eVehicleDealership.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eVehicleDealership.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcjeneController : BaseCRUDController<Modeli.OcjenaModel, object, Modeli.OcjenaModel, Modeli.OcjenaModel>
    {
        private readonly OcjeneService service;

        public OcjeneController(OcjeneService service) : base(service)
        {
            this.service = service;
        }

        [HttpGet("GetOcjeneByVozilo/{voziloId}")]
        public List<OcjenaModel> GetOcjeneByVozilo(int voziloId)
        {
            return service.GetByVozilo(voziloId);
        }

        [HttpGet("GetOcjenaByVoziloAndKorisnik/{voziloId}/{korisnikId}")]
        public int GetOcjenaByVoziloAndKorisnik(int voziloId, int korisnikId)
        {
            return service.GetOcjenaByVoziloAndKorisnik(voziloId, korisnikId);
        }
    }
}