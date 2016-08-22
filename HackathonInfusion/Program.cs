using System;

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