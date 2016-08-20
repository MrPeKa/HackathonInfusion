using System;
using System.Net.Http;
using System.Net.Http.Headers;

using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Drawing;

namespace HackathonInfusion
{

    public class Program
    {
        public PositionInfo pos;
        public StartCoordinates start;
        public static void Main()
        {

            //Connection connect = new Connection("kgruh240","das");
            //connect.Greetings();
            //Console.ReadKey();
            //Solver solver = new Solver(connect);

            int[,] lab = new int[,]
            {
                { 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 1 },
                { 1, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1 },
                { 1, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 1 }
            };
            Point startPos = new Point(1, 1);
            Point endPos = new Point(3, 5);
            Solver solv = new Solver(new ConnectionMock(lab, startPos, endPos));
            solv.Solve(0);
        }

     
       
    }

}