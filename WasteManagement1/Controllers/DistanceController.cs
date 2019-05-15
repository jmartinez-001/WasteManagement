using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WasteManagement1.Controllers
{
    public class DistanceController
    {       
  
        string _distance;
        public string distance { get { return _distance; } }

        //DistanceMatrix
        public void SendRequest(string origins, string destinations)
        {
            string google = "https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=" + origins + "&destinations=" + destinations + "&key=" + Models.Key.GetKey();
            RunAsync(google).GetAwaiter().GetResult();

        }

        public class JSONObj
        {
            public Rows[] rows { get; set; }
        }                   

        public class Rows
        {
            public Elements[] Elements { get; set; }
        }

        public class Elements
        {
            public Distance Distance { get; set; }
        }

        public class Distance
        {
            public string Text { get; set; }
        }

        static HttpClient client = new HttpClient();

        async Task<JSONObj> GetResults(string url)
        {
            JSONObj result = null;
            HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<JSONObj>();
            }
            return result;

        }

        async Task RunAsync(string url)
        {

            client.BaseAddress = new Uri(url);
            try
            {
                JSONObj result = await GetResults(url).ConfigureAwait(false);
                _distance = result.rows[0].Elements[0].Distance.Text;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}