using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eVehicleDealership.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eVehicleDealership.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradoviController : BaseController<Modeli.Grad, object>
    {
        private readonly GradoviService _service;

        public GradoviController(GradoviService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("GetByDrzava/{drzavaId}")]
        public IList<Modeli.Grad> GetByDrzava(int drzavaId)
        {
            return _service.GetByDrzava(drzavaId);
        }
    }
}