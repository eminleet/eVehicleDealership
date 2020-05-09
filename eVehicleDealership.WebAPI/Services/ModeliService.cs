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
    public class ModeliService : BaseCRUDService<Modeli.Model, ModelSearchRequest, Model, ModelInsertRequest, Modeli.Model>
    {
        public ModeliService(eVehicleDealershipContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IList<Modeli.Model> Get(ModelSearchRequest search)
        {
            var query = _context.Set<Model>().AsQueryable();

            if (search?.ProizvodjacId.HasValue == true)
            {
                query = query.Where(x => x.ProizvodjacId == search.ProizvodjacId);
            }

            var result = new List<Modeli.Model>();

            foreach (var model in query.Include(x => x.Proizvodjac))
            {
                result.Add(new Modeli.Model
                {
                    ModelId = model.ModelId,
                    Naziv = model.Naziv,
                    ProizvodjacId = model.ProizvodjacId,
                    Proizvodjac = model.Proizvodjac.Naziv
                });
            }

            return result.OrderBy(x => x.ProizvodjacId).ThenBy(x => x.Naziv).ToList();
        }
    }
}
