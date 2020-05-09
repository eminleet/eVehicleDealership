using AutoMapper;
using eVehicleDealership.Modeli.Requests;
using eVehicleDealership.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace eVehicleDealership.WebAPI.Services
{
    public class ProizvodjaciService : BaseCRUDService<Modeli.Proizvodjac, ProizvodjacSearchRequest, Proizvodjac, ProizvodjacUpsertRequest, ProizvodjacUpsertRequest>
    {
        public ProizvodjaciService(eVehicleDealershipContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IList<Modeli.Proizvodjac> Get(ProizvodjacSearchRequest search)
        {
            var query = _context.Set<Proizvodjac>().AsQueryable();

            if (search?.DrzavaId.HasValue == true)
            {
                query = query.Where(x => x.DrzavaId == search.DrzavaId);
            }

            query = query.OrderBy(x => x.Naziv);

            return _mapper.Map<List<Modeli.Proizvodjac>>(query.ToList());
        }
    }
}