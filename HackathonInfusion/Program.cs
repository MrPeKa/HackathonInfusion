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

            Connection connect = new Connection("kgruh240","r1_2");
            Solver solver = new Solver(connect);
            solver.Solve(0);
            Console.ReadKey();

        }

    }

}