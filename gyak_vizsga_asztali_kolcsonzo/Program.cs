using gyak_vizsga_asztali_kolcsonzo.Models;
using NetworkHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gyak_vizsga_asztali_kolcsonzo
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUrl = "http://localhost:3000";
            List<Kolcsonzo> kolcsonzok= Backend.GET(baseUrl+ "/kolcsonzok").Send().ToList<Kolcsonzo>();
            List<Kolcsonzes> kolcsonzesek= Backend.GET(baseUrl+ "/kolcsonzesek").Send().ToList<Kolcsonzes>();
            List<Konyv> konyvek= Backend.GET(baseUrl+ "/konyvek").Send().ToList<Konyv>();
            // feladat1: Mi a legdrágább könyv? (szerző, cím, ár)
            // feladat2: Melyik könyv (név) volt a legnépszerűbb?
            // feladat3: listázza ki, melyik felhaasználó(név) mennyi db könyvet kölcsönzött ki, rendezze név szerint csökkenő csökkenőbe
            // feladat4: Mennyi olyan könyv van, ahol a szerző neve "J." - al kezdődik
            // feladat5: van-e olyan könyv amelynek címében szerepel a gyűrű szó? ne legyen kis/nagybetű érzékeny keresés!
            feladat1(konyvek);
            feladat2(kolcsonzesek, konyvek);
            feladat3(kolcsonzesek, kolcsonzok);
            feladat4(konyvek);
            feladat5(konyvek);
            Console.ReadKey();
        }

        private static void feladat5(List<Konyv> konyvek)
        {
            Console.WriteLine((konyvek.Any(x => x.cim.ToLower().Contains("gyűrű"))?"van":"nincs")+ " olyan könyv amelynek címében szerepel a gyűrű szó");
        }

        private static void feladat4(List<Konyv> konyvek)
        {
            Console.WriteLine($"{konyvek.Where(x => x.szerzo.StartsWith("J.")).Count()}db");
        }

        private static void feladat3(List<Kolcsonzes> kolcsonzesek, List<Kolcsonzo> kolcsonzok)
        {
            kolcsonzesek.GroupBy(x => x.kolcsonzo_id).Select(x => new { kolcsonzo_nev = kolcsonzok.Where(y => y.kolcsonzo_id == x.Key).First().nev, db = x.Sum(y => y.peldanyszam) })
                .OrderByDescending(x => x.kolcsonzo_nev).ToList().ForEach(x => Console.WriteLine($"{x.kolcsonzo_nev}:  {x.db}db"));
        }

        private static void feladat2(List<Kolcsonzes> kolcsonzesek, List<Konyv> konyvek)
        {
            var result= kolcsonzesek.GroupBy(x => x.konyv_id)
                .Select(x => new { konyv_nev = konyvek.Where(y=>y.konyv_id== x.Key).First().cim, darab = x.Sum(y => y.peldanyszam) })
                .OrderBy(x=>x.darab).First();
            Console.WriteLine($"{result.konyv_nev}: {result.darab}db");
        }

        private static void feladat1(List<Konyv> konyvek)
        {
            Konyv k = konyvek.OrderBy(x => x.ar).Last();
            Console.WriteLine($"{k.szerzo} {k.cim} {k.ar}");
        }
    }
}
