using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eVehicleDealership.Modeli.Requests;
using eVehicleDealership.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eVehicleDealership.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UlogeController : BaseController<Modeli.Uloga, UlogaSearchRequest>
    {
        public UlogeController(IService<Modeli.Uloga, UlogaSearchRequest> service) : base(service)
        {
        }
    }
}