using AutoMapper;
using eVehicleDealership.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVehicleDealership.WebAPI.Services
{
    public class BaseCRUDService<TModel, TSearch, TDatabase, TInsert, TUpdate> : BaseService<TModel, TSearch, TDatabase>, ICRUDService<TModel, TSearch, TInsert, TUpdate> where TDatabase: class
    {
        public BaseCRUDService(eVehicleDealershipContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual TModel Insert(TInsert request)
        {
            var entity = _mapper.Map<TDatabase>(request);

            _context.Set<TDatabase>().Add(entity);
            _context.SaveChanges();

            return _mapper.Map<TModel>(entity);
        }

        public virtual TModel Update(int id, TUpdate request)
        {
            var entity = _context.Set<TDatabase>().Find(id);

            _mapper.Map(request, entity);
            _context.SaveChanges();

            return _mapper.Map<TModel>(entity);
        }
    }
}
