using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HackathonInfusion
{

    public class Program
    {
        public static void Main()
        {
            Team currentTeam = new Team("kgruh240");
            Maze currentMaze  = new Maze("id_2");
            Action postAction = new Action(ActionType.StartCompetition,currentTeam,currentMaze);
            RunAsync<string>().Wait();

        }

        public static async Task RunAsync<T>()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://192.168.0.50:12345/maze-game/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // HTTP GET
                    HttpResponseMessage response = await client.GetAsync("");
                    if (response.IsSuccessStatusCode)
                    {

                    }

                    // HTTP POST
                    Team team = new Team("kgruh240");
                    var postData = JsonConvert.SerializeObject(team, Formatting.Indented);
                    response = await client.PostAsJsonAsync("GreetTeam", postData);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine(response.Headers);
                    }
                }
                catch
                {
                    Console.WriteLine("d");
                }
            }
            Console.ReadKey();
        }
    }
}