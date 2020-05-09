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
    public class KategorijeController : BaseController<Modeli.Kategorija, object>
    {
        public KategorijeController(IService<Modeli.Kategorija, object> service) : base(service)
        {
        }
    }
}