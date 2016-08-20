using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HackathonInfusion
{

    public class Program
    {
        public static void Main()
        {
            RunAsync<string>().Wait();
        }

        public static async Task RunAsync<T>()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://192.168.0.50:12345/maze-game/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                 //   string result = await response.Content.ReadAsAsync<string>();
                //    Console.WriteLine(result);
                }

                // HTTP POST
                Team team = new Team("kgruh240");
                var postData = JsonConvert.SerializeObject(team, Formatting.Indented);

                response = await client.PostAsJsonAsync("GreetTeam", postData);
                Console.WriteLine(response.StatusCode);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.Headers);
                }
            }
            Console.ReadKey();
        }
    }
}