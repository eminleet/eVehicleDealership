using System;
using System.Collections.Generic;
using System.Text;

namespace eVehicleDealership.Modeli
{
    public static class GodisteModel
    {
        public static List<int> Godine = new List<int>();
        public static List<int> GetGodine()
        {
            int trenutnaGodina = DateTime.Now.Year;
            for (int i = trenutnaGodina; i >= trenutnaGodina - 100; i--)
            {
                Godine.Add(i);
            }

            return Godine;
        }
    }
}
