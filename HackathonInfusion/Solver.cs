using System;
using System.Collections.Generic;
using System.Drawing;

namespace HackathonInfusion
{
    public class Solver
    {
        private readonly IConnection _connection;
        private StartCoordinates _coordinates;
        private readonly Stack<Point> _currentPath;
        private Point  _currentPosition, _endPosition;
        private readonly Dictionary<Point, int> _visitedCoordinates;


        public Solver(IConnection conn)
        {
            if (conn == null)
                throw new ArgumentNullException("No connection.");

            _connection = conn;
            _visitedCoordinates = new Dictionary<Point, int>();
            _currentPath = new Stack<Point>();
        }

        public bool Solve(int maxSteps)
        {
            var outcome = false;

            SetUp();  

            outcome = RecursiveSolve(_coordinates.StartX, _coordinates.StartY);
            Console.WriteLine("Result: {0}", outcome);

            Console.WriteLine("Path:");
            Point p;
            while (_currentPath.Count > 0)
            {
                p = _currentPath.Pop();
                Console.WriteLine("P[{0}, {1}]", p.X, p.Y);
            }

            return outcome;
        }


        private void SetUp()
        {
            _coordinates = _connection.StartCompetition();
            _endPosition = new Point(_coordinates.EndX, _coordinates.EndY);
            _currentPosition = new Point(_coordinates.StartX, _coordinates.StartY);
        }


        private bool RecursiveSolve(int x, int y)
        {
            if (x == _endPosition.X && y == _endPosition.Y)
                return true;

            var currentPoint = new Point(x, y);
            if (AlreadyVisited(x, y) > 0)
            {
                return false;
            }
            _visitedCoordinates.Add(currentPoint, 1);

            var nearScan = _connection.Scan();

            PositionInfo posInfo;

            if (nearScan.WestWallDistance != 0)
            {
                posInfo = _connection.MoveLeft();
                Console.WriteLine("X: {0} Y: {1}", posInfo.X, posInfo.Y);

                if (!posInfo.Failure)
                {
                    if (RecursiveSolve(x - 1, y))
                    {
                        _currentPath.Push(currentPoint);
                        return true;
                    }
                    _connection.MoveRight();
                }
            }

            if (nearScan.EastWallDistance != 0)
            {
                posInfo = _connection.MoveRight();
                Console.WriteLine("X: {0} Y: {1}", posInfo.X, posInfo.Y);

                if (!posInfo.Failure)
                {
                    if (RecursiveSolve(x + 1, y))
                    {
                        _currentPath.Push(currentPoint);
                        return true;
                    }
                    _connection.MoveLeft();
                }
            }

            if (nearScan.SouthWallDistance != 0)
            {
                posInfo = _connection.MoveDown();
                Console.WriteLine("X: {0} Y: {1}", posInfo.X, posInfo.Y);

                if (!posInfo.Failure)
                {
                    if (RecursiveSolve(x, y - 1))
                    {
                        _currentPath.Push(currentPoint);
                        return true;
                    }
                    _connection.MoveUp();
                }
            }

            if (nearScan.NorthWallDistance != 0)
            {
                posInfo = _connection.MoveUp();
                Console.WriteLine("X: {0} Y: {1}", posInfo.X, posInfo.Y);

                if (!posInfo.Failure)
                {
                    if (RecursiveSolve(x, y + 1))
                    {
                        _currentPath.Push(currentPoint);
                        return true;
                    }
                    _connection.MoveDown();
                }
            }

            return false;
        }

        private int AlreadyVisited(int x, int y)
        {
            var newPoint = new Point(x, y);
            var val = 0;
            _visitedCoordinates.TryGetValue(newPoint, out val);
            return val;
        }
    }
}