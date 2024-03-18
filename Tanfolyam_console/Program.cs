using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkHelper;
using Tanfolyam_console.Models;

namespace Tanfolyam_console
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUrl = "http://localhost:3000";
            var tanulok= Backend.GET(baseUrl + "/tanulok").Send().ToList<Tanulo>();
            var ertekelesek = Backend.GET(baseUrl + "/ertekelesek").Send().ToList<Ertekeles>();
            var tantargyak = Backend.GET(baseUrl + "/tantargyak").Send().ToList<Tantargy>();
            /*
            - Kérdezze le a tanulók átlagéletkorát! (elősször az életkorukat)
            - Kérdezze le azon tanulók nevét, akiknek még nincs egyetlen jegye sem angolból! 
                (Segéd lekérdezés: kinek van jegye angolból)
            - Készítsen lekérdezést, amely megjeleníti a tantárgyakat és a tantárgyhoz tartozó jegyek átlagát!
            - Készítsen lekérdezést, amely tartalmazza Kovács Elek minden jegyét! 
                A lekérdezésben jelenjen meg a tantárgy neve és az érdemjegy!
             */
            feladat1(tanulok);
            feladat2(tantargyak, ertekelesek, tanulok);
            feladat3(tantargyak, ertekelesek);
            feladat4(tantargyak, ertekelesek, tanulok);
            Console.ReadKey();

        }

        private static void feladat4(List<Tantargy> tantargyak, List<Ertekeles> ertekelesek, List<Tanulo> tanulok)
        {
            Console.WriteLine("Kovács Elek jegyei");
            int kEId = tanulok.Where(x => x.nev == "Kovács Elek").First().id;
            ertekelesek.Where(x => x.tanuloid == kEId).Select(x => new {
                tantargyNev=tantargyak.Where(y=>y.id== x.tantargyid).First().megnevezes,
                erdemjegye=x.jegy
            }).ToList().ForEach(x => Console.WriteLine($"{x.tantargyNev}: {x.erdemjegye}"));
        }

        private static void feladat3(List<Tantargy> tantargyak, List<Ertekeles> ertekelesek)
        {
            ertekelesek.GroupBy(x => x.tantargyid).Select(x => new 
            {
                tantargyNev=tantargyak.Where(y=>y.id== x.Key).First().megnevezes,
                jegyekAtlaga=x.Average(y=>y.jegy)
            }).ToList().ForEach(x => Console.WriteLine($"{x.tantargyNev}: {x.jegyekAtlaga:0.00}"));
        }

        private static void feladat2(List<Tantargy> tantargyak, List<Ertekeles> ertekelesek, List<Tanulo> tanulok)
        {
            int angolTargyId = tantargyak.Where(x => x.megnevezes.ToLower().Contains("angol")).First().id;
            ertekelesek.GroupBy(x => x.tanuloid).Select(x => new
            {
                tanuloNev=tanulok.Where(y=>y.id== x.Key).First().nev,
                angolJegyekSzama=x.Count(y=>y.tantargyid==angolTargyId)
            }).Where(x => x.angolJegyekSzama == 0).ToList().ForEach(x => Console.WriteLine(x.tanuloNev));
        }

        private static void feladat1(List<Tanulo> tanulok)
        {
            int atlagEletkor= (int)tanulok.Average(x => DateTime.Now.Subtract(x.szuletesiido).TotalDays / 365);
            Console.WriteLine(atlagEletkor);
        }
    }
}
