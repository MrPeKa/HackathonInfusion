using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonInfusion
{
    public class Solver
    {
        private IConnection _connection;
        private StartCoordinates _coordinates;
        private Dictionary<Point, int> _visitedCoordinates;
        private Point _leftDistance, _currentPosition, _endPosition;
        private int _xDirection, _yDirection;
        private Stack<Point> _currentPath;
        //public Queue<Point> _path;
        private ActionType lastDirection;


        public Solver(IConnection conn)
        {
            if (conn == null)
                throw new ArgumentNullException("Connection null");

            _connection = conn;
            _visitedCoordinates = new Dictionary<Point, int>();
            _currentPath = new Stack<Point>();
            //_path = new Queue<Point>();
        }
        
        public bool Solve(int maxSteps)
        {
            bool outcome = false;
            int steps = 0;

            SetUp();
            CalculateDistance();

            outcome = RecursiveSolve(_coordinates.StartX, _coordinates.StartY);
            Console.WriteLine("Wynik: {0}", outcome);

            Console.WriteLine("Ścieżka:");
            Point p;
            while(_currentPath.Count > 0)
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

        private void CalculateDistance()
        {
            var xDist = _endPosition.X - _currentPosition.X;
            var yDist = _endPosition.Y - _currentPosition.Y;
            _leftDistance = new Point(xDist, yDist);
        }

        private void ChooseDirection()
        {
            _xDirection = _leftDistance.X < 0 ? -1 : 1;
            _yDirection = _leftDistance.Y < 0 ? -1 : 1;
        }


        //private bool Move()
        //{
        //    PositionInfo positionInfo;
            
        //    if(_xDirection < 0 && _yDirection < 0)
        //    {
        //        int pointVisited = PointVisitedStatus(-1, 0);
        //        if(pointVisited <= 0)
        //        {
        //            positionInfo = _connection.MoveLeft();
        //        }

        //        pointVisited = PointVi
                
        //    }
        //    else if(_xDirection > 0 && _yDirection < 0)
        //    {

        //    }
        //    else if(_xDirection < 0 && _yDirection > 0)
        //    {

        //    }
        //    else
        //    {

        //    }
        //}

        private bool RecursiveSolve(int x, int y)
        {
            if (x == _endPosition.X && y == _endPosition.Y)
                return true;

            var currentPoint = new Point(x, y);
            if(AlreadyVisited(x, y) > 0)
            {
                return false;
            }
            else
            {
                _visitedCoordinates.Add(currentPoint, 1);
            }

            var nearScan = _connection.Scan();

            PositionInfo posInfo;

            if (nearScan.WestWallDistance != 0)
            {
                posInfo = _connection.MoveLeft();

                if (!posInfo.Failure) // można ruszać w lewo
                {
                    if (RecursiveSolve(x - 1, y))
                    {
                        //_path.Enqueue(currentPoint);
                        _currentPath.Push(currentPoint);
                        return true;
                    }
                    else
                    {
                        _connection.MoveRight();
                    }
                }
            }

            if (nearScan.EastWallDistance != 0)
            {
                posInfo = _connection.MoveRight();
                if (!posInfo.Failure) // można ruszać w prawo
                {
                    if (RecursiveSolve(x + 1, y))
                    {
                        //_path.Enqueue(currentPoint);
                        _currentPath.Push(currentPoint);
                        return true;
                    }
                    else
                    {
                        _connection.MoveLeft();
                    }
                }
            }

            if (nearScan.SouthWallDistance != 0)
            {
                posInfo = _connection.MoveDown();
                if (!posInfo.Failure)
                {
                    if (RecursiveSolve(x, y - 1))
                    {
                        //_path.Enqueue(currentPoint);
                        _currentPath.Push(currentPoint);
                        return true;
                    }
                    else
                    {
                        _connection.MoveUp();
                    }
                }
            }

            if (nearScan.NorthWallDistance != 0)
            {
                posInfo = _connection.MoveUp();
                if (!posInfo.Failure)
                {
                    if (RecursiveSolve(x, y + 1))
                    {
                        //_path.Enqueue(currentPoint);
                        _currentPath.Push(currentPoint);
                        return true;
                    }
                    else
                    {
                        _connection.MoveDown();
                    }
                }
            }

            return false;
        }

        //private void CheckLeft(Point pos)
        //{
            
        //}

        //private void CheckRight(Point pos)
        //{

        //}

        //private void CheckUp(Point pos)
        //{

        //}

        //private void CheckDown(Point pos)
        //{

        //}

        private int AlreadyVisited(int x, int y)
        {
            var newPoint = new Point(x, y);
            int val = 0;
            _visitedCoordinates.TryGetValue(newPoint, out val);
            return val;
        }
    }
}
