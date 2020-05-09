using AutoMapper;
using eVehicleDealership.Modeli.Requests;
using eVehicleDealership.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVehicleDealership.WebAPI.Services
{
    public class UlogeService : BaseService<Modeli.Uloga, UlogaSearchRequest, Uloga>
    {
        public UlogeService(eVehicleDealershipContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IList<Modeli.Uloga> Get(UlogaSearchRequest search)
        {

            if (search?.KorisnikId.HasValue == true)
            {
                var query = _context.Set<KorisnikUloga>().Where(x => x.KorisnikId == search.KorisnikId)
                                                         .Include(x => x.Uloga)
                                                         .Select(x => new { x.UlogaId, x.Uloga.Naziv })
                                                         .OrderBy(x => x.Naziv)
                                                         .ToList();

                var list = new List<Modeli.Uloga>();

                foreach (var item in query)
                {
                    list.Add(new Modeli.Uloga
                    {
                        Naziv = item.Naziv,
                        UlogaId = item.UlogaId
                    });
                }

                return list;
            }

            return _mapper.Map<List<Modeli.Uloga>>(_context.Set<Uloga>().OrderBy(x => x.Naziv).ToList());
        }
    }
}
