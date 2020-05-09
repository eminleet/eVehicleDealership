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
    public class BaseCRUDController<TModel, TSearch, TInsert, TUpdate> : BaseController<TModel, TSearch>
    {
        protected readonly ICRUDService<TModel, TSearch, TInsert, TUpdate> _service = null;
        public BaseCRUDController(ICRUDService<TModel, TSearch, TInsert, TUpdate> service) : base(service)
        {
            _service = service;
        }

        [HttpPost]
        public TModel Insert(TInsert request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{id}")]
        public TModel Update(int id, [FromBody]TUpdate request)
        {
            return _service.Update(id, request);
        }
    }
}