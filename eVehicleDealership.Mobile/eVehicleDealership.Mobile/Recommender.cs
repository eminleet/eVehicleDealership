using eVehicleDealership.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVehicleDealership.Mobile
{
    public class Recommender
    {
        Dictionary<int, List<OcjenaModel>> oglasi = new Dictionary<int, List<OcjenaModel>>();

        public async Task<List<Oglas>> GetSlicneOglase(int voziloId)
        {
            await UcitajOglase(voziloId);
            List<Oglas> preporuceniOglasi = new List<Oglas>();

            List<OcjenaModel> ocjenePosmatranogOglasa = await APIService.GetOcjeneByVozilo(voziloId);
            if (ocjenePosmatranogOglasa == null)
            {
                return preporuceniOglasi;
            }
            ocjenePosmatranogOglasa = ocjenePosmatranogOglasa.OrderBy(x => x.KorisnikId).ToList();

            List<OcjenaModel> zajednickeOcjene1 = new List<OcjenaModel>();
            List<OcjenaModel> zajednickeOcjene2 = new List<OcjenaModel>();

            foreach (var item in oglasi.ToList())
            {
                foreach (var o in ocjenePosmatranogOglasa)
                {
                    if (item.Value.Where(x => x.KorisnikId == o.KorisnikId).Count() > 0)
                    {
                        zajednickeOcjene1.Add(o);
                        zajednickeOcjene2.Add(item.Value.Where(x => x.KorisnikId == o.KorisnikId).FirstOrDefault());
                    }
                }

                double slicnost = GetSlicnost(zajednickeOcjene1, zajednickeOcjene2);

                if (slicnost > 0.5)
                {
                    preporuceniOglasi.Add(await APIService.GetOglasByVozilo(item.Key));
                }

                zajednickeOcjene1.Clear();
                zajednickeOcjene2.Clear();
            }

            return preporuceniOglasi;
        }

        private double GetSlicnost(List<OcjenaModel> zajednickeOcjene1, List<OcjenaModel> zajednickeOcjene2)
        {
            if (zajednickeOcjene1.Count != zajednickeOcjene2.Count)
                return 0;

            double brojnik = 0, nazivnik1 = 0, nazivnik2 = 0;

            for (int i = 0; i < zajednickeOcjene1.Count; i++)
            {
                brojnik += zajednickeOcjene1[i].DataOcjena * zajednickeOcjene2[i].DataOcjena;
                nazivnik1 += zajednickeOcjene1[i].DataOcjena * zajednickeOcjene1[i].DataOcjena;
                nazivnik2 += zajednickeOcjene2[i].DataOcjena * zajednickeOcjene2[i].DataOcjena;
            }
            nazivnik1 = Math.Sqrt(nazivnik1);
            nazivnik2 = Math.Sqrt(nazivnik2);

            double nazivnik = nazivnik1 * nazivnik2;
            if (nazivnik == 0)
                return 0;
            else
                return brojnik / nazivnik;
        }

        private async Task UcitajOglase(int voziloId)
        {
            List<Oglas> oglasiList = await APIService.GetOglase();
            var oglasToRemove = oglasiList.Find(x => x.VoziloId == voziloId);
            oglasiList.Remove(oglasToRemove);

            List<OcjenaModel> ocjene = new List<OcjenaModel>();

            foreach (var item in oglasiList)
            {
                ocjene = await APIService.GetOcjeneByVozilo(item.VoziloId);
                if (ocjene != null)
                {
                    ocjene = ocjene.OrderBy(x => x.KorisnikId).ToList();
                    oglasi.Add(item.VoziloId, ocjene);
                }
            }
        }
    }
}