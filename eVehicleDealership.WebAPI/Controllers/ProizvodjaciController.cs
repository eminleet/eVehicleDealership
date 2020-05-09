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
    public class ProizvodjaciController : BaseCRUDController<Modeli.Proizvodjac, ProizvodjacSearchRequest, ProizvodjacUpsertRequest, ProizvodjacUpsertRequest>
    {
        public ProizvodjaciController(ICRUDService<Modeli.Proizvodjac, ProizvodjacSearchRequest, ProizvodjacUpsertRequest, ProizvodjacUpsertRequest> service) : base(service)
        {
        }
    }
}