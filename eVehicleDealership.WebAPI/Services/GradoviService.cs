using AutoMapper;
using eVehicleDealership.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVehicleDealership.WebAPI.Services
{
    public class GradoviService : BaseService<Modeli.Grad, object, Grad>
    {
        public GradoviService(eVehicleDealershipContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public IList<Modeli.Grad> GetByDrzava(int drzavaId)
        {
            var result = _context.Gradovi.Where(x => x.DrzavaId == drzavaId).OrderBy(x => x.Naziv);
            return _mapper.Map<List<Modeli.Grad>>(result);
        }
    }
}
