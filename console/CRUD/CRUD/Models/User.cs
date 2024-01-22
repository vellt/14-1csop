using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Models // névtér
{
    public class User // osztály
    {
        public int id { get; set; } // tulajdonság/ property
        public string firstname { get; set; }
        public string lastname { get; set; }
        public DateTime date { get; set; }

        private string emailMezo; // mező
        public string email // tulajdonság/property
        {
            get
            {
                // ha üresen érkezik az adat, akkor helyettesítjük
                // lekérdezéskor a következő szöveggel
                if (emailMezo == "")
                {
                    return "Nincs adat";
                }
                else
                {
                    return emailMezo;
                }
            }
            set
            {
                emailMezo = value;
            }
        }

        public string FullName()
        {
            return $"{firstname} {lastname}";
        }
    }
}
