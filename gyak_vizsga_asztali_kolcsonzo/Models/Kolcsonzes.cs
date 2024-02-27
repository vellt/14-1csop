using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gyak_vizsga_asztali_kolcsonzo.Models
{
    public class Kolcsonzes
    {
        public string display { get; set; }
        public DateTime kivitel_datum { get; set; }
        public int kolcsonzo_id { get; set; }
        public int konyv_id { get; set; }
        public int peldanyszam { get; set; }

        public override string ToString()
        {
            return display;
        }
    }
}
