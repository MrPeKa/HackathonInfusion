using System;
using System.Drawing;

namespace HackathonInfusion
{

    public class Program
    {
        public static void Main()
        {

            Connection connect = new Connection("kgruh240","round3");
            Solver solver = new Solver(connect);
            solver.Solve(0);
            Console.ReadKey();
/*
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
            */
        }

    }

}