using System;
using System.Net.Http;
using System.Net.Http.Headers;

using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HackathonInfusion
{

    public class Program
    {
        public PositionInfo pos;
        public StartCoordinates start;
        public static void Main()
        {

            Connection connect = new Connection("kgruh240","das");
            connect.Greetings();
            Console.ReadKey();
            Solver solver = new Solver(connect);


        }

     
       
    }

}