using AutoMapper;
using eVehicleDealership.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVehicleDealership.WebAPI.Services
{
    public class BaseService<TModel, TSearch, TDatabase> : IService<TModel, TSearch> where TDatabase : class
    {
        protected readonly eVehicleDealershipContext _context;
        protected readonly IMapper _mapper;

        public BaseService(eVehicleDealershipContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual IList<TModel> Get(TSearch search)
        {
            return _mapper.Map<List<TModel>>(_context.Set<TDatabase>().ToList());
        }

        public virtual TModel GetById(int id)
        {
            return _mapper.Map<TModel>(_context.Set<TDatabase>().Find(id));
        }
    }
}