using System;
using System.Collections.Generic;
using System.Text;

namespace eVehicleDealership.Modeli
{
    public static class KubikazaModel
    {
        public static List<string> Kubikaze = new List<string>();
        public static List<string> GetKubikaze()
        {
            for (double i = 0.8; i <= 6.1; i += 0.1)
            {
                if (i.ToString() == "1")
                {
                    Kubikaze.Add("1.0");
                }
                else if (i.ToString() == "2")
                {
                    Kubikaze.Add("2.0");
                }
                else if (i.ToString() == "3")
                {
                    Kubikaze.Add("3.0");
                }
                else if (i.ToString() == "4")
                {
                    Kubikaze.Add("4.0");
                }
                else if (i.ToString() == "5")
                {
                    Kubikaze.Add("5.0");
                }
                else if (i.ToString() == "6")
                {
                    Kubikaze.Add("6.0");
                }
                else { Kubikaze.Add(i.ToString()); }
            }
            Kubikaze.AddRange(new string[] { "6.2", "6.3", "6.3", "6.4", "6.5", "6.6", "6.7", "6.8", "6.9", "7.0", "7.1", "7.2", "7.3", "7.4", "7.5" });
            return Kubikaze;
        }

    }
}
