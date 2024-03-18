using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanfolyam_console.Models
{
    public class Tanulo
    {
        public int id { get; set; }
        public string nev { get; set; } // varchar
        public string telefonszam { get; set; } // varchar
        public DateTime szuletesiido { get; set; } // date
        public string email { get; set; } // varchar
    }
}
