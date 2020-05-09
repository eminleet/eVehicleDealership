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
    public class DrzaveController : BaseController<Modeli.Drzava, object>
    {
        public DrzaveController(IService<Modeli.Drzava, object> service) : base(service)
        {
        }
    }
}