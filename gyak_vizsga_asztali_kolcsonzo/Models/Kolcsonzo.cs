using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gyak_vizsga_asztali_kolcsonzo.Models
{
    public class Kolcsonzo
    {
        public int kolcsonzo_id { get; set; }
        public string nev { get; set; }

        public override string ToString()
        {
            return nev;
        }
    }
}
