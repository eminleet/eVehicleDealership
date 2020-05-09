using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using eVehicleDealership.Modeli;
using eVehicleDealership.WebAPI.Database;
using eVehicleDealership.WebAPI.Helpers;
using eVehicleDealership.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eVehicleDealership.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlikeVozilaController : BaseCRUDController<Modeli.SlikaVozilaModel, object, Modeli.SlikaVozilaModel, Modeli.SlikaVozilaModel>
    {
        private readonly SlikeVozilaService _service;

        public SlikeVozilaController(SlikeVozilaService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("GetByVozilo/{voziloId}")]
        public IList<Modeli.SlikaVozilaModel> GetByVozilo(int voziloId)
        {
            return _service.GetByVozilo(voziloId);
        }
    }
}