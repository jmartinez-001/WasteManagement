using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WasteManagement1.Controllers
{
    public class GeocodeController : Controller
    {
        string Latitude;
        string Longitude;
        // GET: Geocode
        public void SendRequest(string Address)
        {
            string google = "https://maps.googleapis.com/maps/api/geocode/json?address=";
            RetrieveResults(google);

        }

        async Task RetrieveResults(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                
            }
        }
    }
}