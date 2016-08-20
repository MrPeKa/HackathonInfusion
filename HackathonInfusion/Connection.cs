using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace HackathonInfusion
{
    class Connection : IConnection
    {
        public static StartCoordinates StartPos { get; set; }
        public static PositionInfo Position { get; set; }
        public static WallsPosition WallPosition { get; set; }
        public static bool Success { get; set; }

        public Team Details;


        public Connection(string teamName, string mazeName)
        {
            Details = new Team(teamName,mazeName);
            Success = true;

        }

        public StartCoordinates StartCompetition()
        {
            var currentAction = ActionType.StartCompetition;
            RunAsync(Details.GetJson(), currentAction).Wait();
            return StartPos;
        }

        public PositionInfo MoveUp()
        {
            var currentAction = ActionType.MoveUp;
            RunAsync(Details.GetJson(), currentAction).Wait();
            return Position;
        }

        public PositionInfo MoveDown()
        {
            var currentAction = ActionType.MoveDown;
            RunAsync(Details.GetJson(), currentAction).Wait();
            return Position;
        }

        public PositionInfo MoveLeft()
        {
            var currentAction = ActionType.MoveLeft;
            RunAsync(Details.GetJson(), currentAction).Wait();
            return Position;
        }

        public PositionInfo MoveRight()
        {
            var currentAction = ActionType.MoveRight;
            RunAsync(Details.GetJson(), currentAction).Wait();
            return Position;
        }

        public WallsPosition Scan()
        {
            var currentAction = ActionType.Scan;
            RunAsync(Details.GetJson(), currentAction).Wait();
            return WallPosition;
        }


        public WallsPosition ScanLeft()
        {
            var currentAction = ActionType.ScanLeft;
            RunAsync(Details.GetJson(), currentAction).Wait();
            return WallPosition;
        }

        public WallsPosition ScanRight()
        {
            var currentAction = ActionType.ScanRight;
            RunAsync(Details.GetJson(), currentAction).Wait();
            return WallPosition;
        }

        public WallsPosition ScanUp()
        {
            var currentAction = ActionType.ScanUp;
            RunAsync(Details.GetJson(), currentAction).Wait();
            return WallPosition;
        }

        public WallsPosition ScanDown()
        {
            var currentAction = ActionType.ScanDown;
            RunAsync(Details.GetJson(), currentAction).Wait();
            return WallPosition;
        }

        public bool CheckConnection()
        {
            return Success;
        }

        public void Greetings()
        {
            var currentAction = ActionType.GreetTeam;
            RunAsync(Details.GetJson(), currentAction).Wait();
        }


        public static async Task RunAsync(object postData, ActionType action)
        {
            Success = true;
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://192.168.0.50:12345/maze-game/" + action.ToString());
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
                        if (action.Equals(ActionType.Scan) || action.Equals(ActionType.ScanLeft) ||
                            action.Equals(ActionType.ScanRight) || action.Equals(ActionType.ScanUp) ||
                            action.Equals(ActionType.ScanDown))
                        {
                            var returnVal = response.Content.ReadAsAsync<ResponseScan>().Result;
                            WallsPosition walls = new WallsPosition
                            {
                                NorthWallDistance = returnVal.GetUp(),
                                EastWallDistance = returnVal.GetRight(),
                                SouthWallDistance = returnVal.GetDown(),
                                WestWallDistance = returnVal.GetLeft(),
                            };
                            WallPosition = walls;
                        }
                        if (action.Equals(ActionType.GreetTeam))
                        {
                            var returnVal = response.Content.ReadAsAsync<ResponseGreetings>().Result;
                            Console.WriteLine(returnVal.greeting);
                        }
                        if (action.Equals(ActionType.StartCompetition))
                        {
                            var returnVal = response.Content.ReadAsAsync<ResponseOnStartCompetition>().Result;
                            StartCoordinates start = new StartCoordinates
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
                            PositionInfo pos = new PositionInfo
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
