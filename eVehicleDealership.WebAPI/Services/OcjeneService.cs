using AutoMapper;
using eVehicleDealership.Modeli;
using eVehicleDealership.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVehicleDealership.WebAPI.Services
{
    public class OcjeneService : BaseCRUDService<Modeli.OcjenaModel, object, Ocjena, Modeli.OcjenaModel, Modeli.OcjenaModel>
    {
        public OcjeneService(eVehicleDealershipContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override OcjenaModel Insert(OcjenaModel request)
        {
            var existingOcjena = _context.Ocjene.FirstOrDefault(x => x.VoziloId == request.VoziloId && x.KorisnikId == request.KorisnikId);

            if (existingOcjena == null)
            {
                _context.Ocjene.Add(new Ocjena
                {
                    KorisnikId = request.KorisnikId,
                    VoziloId = request.VoziloId,
                    DataOcjena = request.DataOcjena
                });
            }
            else
            {
                existingOcjena.DataOcjena = request.DataOcjena;
            }
            _context.SaveChanges();
            return new OcjenaModel
            {
                ProsjecnaOcjena = _context.Ocjene.Where(x => x.VoziloId == request.VoziloId).Average(x => x.DataOcjena)
            };
        }

        public int GetOcjenaByVoziloAndKorisnik(int voziloId, int korisnikId)
        {
           var result = _context.Ocjene.FirstOrDefault(x => x.VoziloId == voziloId && x.KorisnikId == korisnikId);
            if(result != null)
            {
                return result.DataOcjena;
            }
            else
            {
                return -1;
            }
        }

        public List<OcjenaModel> GetByVozilo(int voziloId)
        {
            var existingOcjena = _context.Ocjene.FirstOrDefault(x => x.VoziloId == voziloId);
            if(existingOcjena == null)
            {
                return null;
            }

            return _mapper.Map<List<OcjenaModel>>(_context.Ocjene.Where(x => x.VoziloId == voziloId).ToList());
        }
    }
}
