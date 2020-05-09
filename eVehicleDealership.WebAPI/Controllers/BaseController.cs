using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eVehicleDealership.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eVehicleDealership.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TModel, TSearch> : ControllerBase
    {
        private readonly IService<TModel, TSearch> _service;

        public BaseController(IService<TModel, TSearch> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual IList<TModel> Get([FromQuery]TSearch search)
        {
            return _service.Get(search);
        }

        [HttpGet("{id}")]
        public virtual TModel GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}