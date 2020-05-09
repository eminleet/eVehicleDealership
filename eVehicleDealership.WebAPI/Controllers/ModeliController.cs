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
    public class ModeliController : BaseCRUDController<Modeli.Model, ModelSearchRequest, ModelInsertRequest, Modeli.Model>
    {
        public ModeliController(ICRUDService<Modeli.Model, ModelSearchRequest, ModelInsertRequest, Modeli.Model> service) : base(service)
        {
        }
    }
}