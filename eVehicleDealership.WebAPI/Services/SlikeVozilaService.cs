using AutoMapper;
using eVehicleDealership.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVehicleDealership.WebAPI.Services
{
    public class SlikeVozilaService : BaseCRUDService<Modeli.SlikaVozilaModel, object, SlikaVozila, Modeli.SlikaVozilaModel, Modeli.SlikaVozilaModel>
    {
        public SlikeVozilaService(eVehicleDealershipContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public IList<Modeli.SlikaVozilaModel> GetByVozilo(int voziloId)
        {
            var result = _context.SlikeVozila.Where(x => x.VoziloId == voziloId);
            return _mapper.Map<List<Modeli.SlikaVozilaModel>>(result);
        }
    }
}
