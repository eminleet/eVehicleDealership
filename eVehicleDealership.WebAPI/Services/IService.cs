using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVehicleDealership.WebAPI.Services
{
    public interface IService<TModel, TSearch>
    {
        IList<TModel> Get(TSearch search);
        TModel GetById(int id);
    }
}
