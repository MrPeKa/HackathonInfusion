using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HackathonInfusion
{
    class Connection : IConnection
    {
        public StartCoordinates start;
        public PositionInfo position;


        public Connection()
        {
            Team details = new Team("kgruh240", "r1_1");
            ActionType currentAction = ActionType.StartCompetition;
            Action postAction = new Action(currentAction, details);
            var json = postAction.GetJsonActionToPost();

            RunAsync<string>(json, postAction).Wait();

        }

        public StartCoordinates StartCompetition()
        {
            return start;
        }

        public PositionInfo MoveUp()
        {
            return position;
        }

        public PositionInfo MoveDown()
        {
            return position;
        }

        public PositionInfo MoveLeft()
        {
            return position;
        }

        public PositionInfo MoveRight()
        {
            return position;
        }

        public bool CheckConnection()
        {
            return true;
        }

        public static async Task RunAsync<T>(object postData, string action)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://192.168.0.50:12345/maze-game/" + action);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // HTTP GET
                    HttpResponseMessage response = await client.GetAsync("");
                    if (response.IsSuccessStatusCode)
                    {

                    }
                    // HTTP POST
                    response = await client.PostAsJsonAsync("", postData);
                    if (response.IsSuccessStatusCode)
                    {
                        if (action.Equals(ActionType.StartCompetition.ToString()))
                        {
                            var returnVal = response.Content.ReadAsAsync<ResponseOnStartCompetition>().Result;
                            StartCoordinates start = new StartCoordinates()
                            {
                                EndX = returnVal.endPosition.x,
                                EndY = returnVal.endPosition.y,
                                StartX = returnVal.startPoint.x,
                                StartY = returnVal.startPoint.y
                            };
                        }
                        else
                        {
                            var returnVal = response.Content.ReadAsAsync<Response>().Result;
                            bool fail = true;
                            if (returnVal.outcome.Equals("failure"))
                                fail = true;
                            else
                            {
                                fail = false;
                            }
                            PositionInfo pos2 = new PositionInfo()
                            {
                                X = returnVal.position.x,
                                Y = returnVal.position.y,
                                Details = returnVal.details,
                                Failure = fail

                            };
                        }

                    }
                }
                catch
                {
                    Console.WriteLine("Problem");
                }
            }
            Console.ReadKey();
        }

    }
}
