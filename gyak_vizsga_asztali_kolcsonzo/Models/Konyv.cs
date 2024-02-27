using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gyak_vizsga_asztali_kolcsonzo.Models
{
    public class Konyv
    {
        public int ar { get; set; }
        public string cim { get; set; }
        public string ISBN { get; set; }
        public int kiadas_eve { get; set; }
        public int konyv_id { get; set; }
        public string szerzo { get; set; }

        public override string ToString()
        {
            return $"{szerzo} - {cim}";
        }
    }
}
