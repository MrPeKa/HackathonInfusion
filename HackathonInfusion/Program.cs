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

            Connection connect = new Connection();
            Solver solver = new Solver(connect);


        }

     
       
    }

}