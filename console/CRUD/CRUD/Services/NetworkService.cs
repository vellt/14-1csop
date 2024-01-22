using CRUD.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services // névtér/namespace
{
    // osztály/class (publikus)
    public class NetworkService
    {
        string url; // mező/field (privát láthatóságú)

        // konstruktor, azaz dedikált inicializáló metódus
        public NetworkService(string url)
        {
            this.url = url;
        }

        // függvény, ami visszatér a lekérdezett elemek listájával
        public List<User> GET()
        {
            var request = WebRequest.Create(this.url);
            request.Method = "GET";
            var response = request.GetResponse();
            string json = new StreamReader(response.GetResponseStream()).ReadToEnd();
            // emiatt kell karakterpontosan a User osztály tulajdonságait megadni
            return JsonConvert.DeserializeObject<List<User>>(json);
        }

        public string POST(User user)
        {
            // kérés elkészítése
            var request = WebRequest.Create(this.url);
            request.Method = "POST";
            request.ContentType = "application/json";

            // kérés kiegészítése body-val
            var streamWriter = new StreamWriter(request.GetRequestStream());
            streamWriter.Write(JsonConvert.SerializeObject(new
            {
                firstname = user.firstname,
                lastname = user.lastname,
                date = user.date,
                email = user.email
            }));
            streamWriter.Close();

            // kérés elküldése
            var response = request.GetResponse();
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        public string DELETE(User user)
        {
            // kérés elkészítése
            var request = WebRequest.Create(this.url);
            request.Method = "DELETE";
            request.ContentType = "application/json";

            // kérés kiegészítése body-val
            var streamWriter = new StreamWriter(request.GetRequestStream());
            streamWriter.Write(JsonConvert.SerializeObject(new
            {
                id = user.id,
            }));
            streamWriter.Close();

            // kérés elküldése
            var response = request.GetResponse();
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        public string PUT(User user)
        {
            // kérés elkészítése
            var request = WebRequest.Create(this.url);
            request.Method = "PUT";
            request.ContentType = "application/json";

            // kérés kiegészítése body-val
            var streamWriter = new StreamWriter(request.GetRequestStream());
            streamWriter.Write(JsonConvert.SerializeObject(new
            {
                id = user.id,
                firstname = user.firstname,
                lastname = user.lastname,
                date = user.date,
                email = user.email
            }));
            streamWriter.Close();

            // kérés elküldése
            var response = request.GetResponse();
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }
    }
}
