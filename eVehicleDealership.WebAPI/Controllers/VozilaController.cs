using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using eVehicleDealership.Modeli;
using eVehicleDealership.Modeli.Requests;
using eVehicleDealership.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eVehicleDealership.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VozilaController : ControllerBase
    {
        private readonly IVozilaService _vozilaService;

        public VozilaController(IVozilaService vozilaService)
        {
            _vozilaService = vozilaService;
        }

        [HttpGet]
        public IList<OglasDetaljiModel> Get([FromQuery]OglasSearchRequest request)
        {
            return _vozilaService.Get(request);
        }

        [HttpGet("{id}")]
        public VoziloDetalji GetById(int id)
        {
            return _vozilaService.GetById(id);
        }

        [HttpGet("GetByKategorija/{kategorijaId}")]
        public IList<VoziloPoKategoriji> GetByKategorija(int kategorijaId)
        {
            return _vozilaService.GetByKategorija(kategorijaId);
        }

        [HttpGet("Pretraga/{search}")]
        public IEnumerable<VoziloSearch> Pretraga(string search)
        {
            return _vozilaService.Pretraga(search);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Modeli.Vozilo vozilo)
        {
            var response = _vozilaService.Insert(vozilo);
            if (!response.Status)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("GetOglase")]
        public IEnumerable<Modeli.Oglas> GetOglase()
        {
            return _vozilaService.GetOglase();
        }

        [HttpPut("{id}")]
        public Modeli.VoziloResponse Update(int id, VoziloUpdateRequest request)
        {
            return _vozilaService.Update(id, request);
        }

        [HttpGet("GetOglasByVozilo/{voziloId}")]
        public Modeli.Oglas GetOglasByVozilo(int voziloId)
        {
            return _vozilaService.GetOglasByVozilo(voziloId);
        }

        [HttpGet("MojiOglasi")]
        public IActionResult MojiOglasi()
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;

            var response = _vozilaService.GetMojeOglase(userEmail);

            if (response == null)
                return NotFound();

            return Ok(response);
        }
    }
}