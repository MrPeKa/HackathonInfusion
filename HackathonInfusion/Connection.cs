using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace HackathonInfusion
{
    class Connection : IConnection
    {
        public static StartCoordinates StartPos;
        public static PositionInfo Position;
        public Team Details;
        public static bool Success;


        public Connection(string teamName, string mazeName)
        {
            Details = new Team(teamName,mazeName);
            Success = true;

        }

        public StartCoordinates StartCompetition()
        {
            var currentAction = ActionType.StartCompetition.ToString();
            RunAsync<string>(Details.GetJson(), currentAction).Wait();
            return StartPos;
        }

        public PositionInfo MoveUp()
        {
            var currentAction = ActionType.MoveUp.ToString();
            RunAsync<string>(Details.GetJson(), currentAction).Wait();
            return Position;
        }

        public PositionInfo MoveDown()
        {
            var currentAction = ActionType.MoveDown.ToString();
            RunAsync<string>(Details.GetJson(), currentAction).Wait();
            return Position;
        }

        public PositionInfo MoveLeft()
        {
            var currentAction = ActionType.MoveLeft.ToString();
            RunAsync<string>(Details.GetJson(), currentAction).Wait();
            return Position;
        }

        public PositionInfo MoveRight()
        {
            var currentAction = ActionType.MoveRight.ToString();
            RunAsync<string>(Details.GetJson(), currentAction).Wait();
            return Position;
        }

        public bool CheckConnection()
        {
            return Success;
        }

        public void Greetings()
        {
            var currentAction = ActionType.GreetTeam.ToString();
            RunAsync<string>(Details.GetJson(), currentAction).Wait();
        }

        public static async Task RunAsync<T>(object postData, string action)
        {
            Success = true;
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
                        if (action.Equals(ActionType.GreetTeam.ToString()))
                        {
                            var returnVal = response.Content.ReadAsAsync<ResponseGreetings>().Result;
                            Console.WriteLine(returnVal.greeting);
                        }
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
                            StartPos = start;
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
                            PositionInfo pos = new PositionInfo()
                            {
                                X = returnVal.position.x,
                                Y = returnVal.position.y,
                                Details = returnVal.details,
                                Failure = fail

                            };
                            Position = pos;
                        }

                    }
                }
                catch
                {
                    Success = false;
                    Console.WriteLine("Problem with parse or with the connection.");
                }
            }
        }

    }
}
