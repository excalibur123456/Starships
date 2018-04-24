using System;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace StarShips
{
    class Program
    {
        /// <summary>
        /// Main processing unit. Take planet distance input from user. Get Starships data from the web service. 
        /// Convert json data to C# object. Process each starship and call GetNumberofStops method
        /// to get number of stops required. Display a list of all the staships and corresponding
        /// re-supply stops required to make the distance between the planets.
        /// </summary>
        static void Main(string[] args)
        {
            string url = "https://swapi.co/api/starships/";
            string jsondata = CallRestMethod(url);

            Console.WriteLine("Please enter the planet distance to cover in MGLT:");
            string planetDistance = Console.ReadLine();

            if (!string.IsNullOrEmpty(jsondata))
            {
                Console.WriteLine("Collection of star ships and the total number of re-supply stops required to make the distance between the planets:");
                var jsondataconv = JsonConvert.DeserializeObject<RootObject>(jsondata);
                foreach (var starship in jsondataconv.results)
                {
                    var numStops = Calculation.GetNumberofStops(starship.consumables, Convert.ToInt32(planetDistance) , Convert.ToInt32(starship.MGLT));
                    Console.WriteLine("{0} : {1}", starship.name, numStops.ToString());
                }
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Get Starships data from the web service
        /// </summary>
        /// <param name="url">Starships web service url</param>
        /// <returns>JSON string</returns>
        public static string CallRestMethod(string url)
        {
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "GET";
            webrequest.ContentType = "application/x-www-form-urlencoded";
            webrequest.Headers.Add("Username", "xyz");
            webrequest.Headers.Add("Password", "abc");
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            webresponse.Close();
            return result;
        }        
    }
}