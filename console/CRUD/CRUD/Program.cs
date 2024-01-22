using CRUD.Models;
using CRUD.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            // példányosítjuk az elkészült NetworkService osztályt
            NetworkService backend = new NetworkService("http://localhost:3000/users");
            
            // adatlehívás (READ)
            List<User> users= backend.GET();
            users.ForEach(x => Console.WriteLine($"{x.id} {x.FullName()} {x.email}")); // kilistázza a megjelölt adatokat
            
            // adatfeltöltés (CREATE)
            User ujUser = new User
            {
                email = "teszt@teszt.com",
                date = DateTime.Now,
                firstname = "Teszt",
                lastname = "Elek"
            };
            string message = backend.POST(ujUser);
            Console.WriteLine(message); // vagy azt írja ki hogy 'hiba' vagy azt hogy 'sikeres felvitel!'


            // adattörlés (DELERE)
            // a 11. id-jú felhasználót töröljük
            string deleteMessage = backend.DELETE(new User { id = 11 });
            Console.WriteLine(deleteMessage); // vagy azt írja ki hogy 'hiba' vagy azt hogy 'sikeres törlés!'
            


            // adatmódosítás (UPDATE)
            // lekérjük a legeleső elemet a bacekendtől, majd módosítjuk az emailt
            User modositottUser = backend.GET()[0];
            modositottUser.email = "teszt@teszt.com";
            string putValasz= backend.PUT(modositottUser);
            Console.WriteLine(putValasz); // vagy azt írja ki hogy 'hiba' vagy azt hogy 'sikeres módosítás!'

            Console.ReadKey();
        }
    }
}
