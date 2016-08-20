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
            Team details = new Team("kgruh240", "id_2");
            ActionType currentAction = ActionType.GreetTeam;
            Action postAction = new Action(currentAction,details);
            var json = postAction.GetJsonActionToPost();

            RunAsync<string>(json,postAction.Type).Wait();

        }

        public static async Task RunAsync<T>(object postData,object action)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://192.168.0.50:12345/maze-game/"+action);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // HTTP GET
                    HttpResponseMessage response = await client.GetAsync("");
                    if (response.IsSuccessStatusCode)
                    {

                    }
                    // HTTP POST
                    response = await client.PostAsJsonAsync("", postData);
                    var returnVal = response.Content.ReadAsAsync<Response>().Result;

                    if (response.IsSuccessStatusCode)
                    {
                       Console.WriteLine(returnVal.Greeting);
                    }
                }
                catch
                {
                    Console.WriteLine("Problem");
                }
            }
            Console.ReadKey();
        }
        public class Response
        {
            public string Greeting { get; set; }
        }
       
    }

}