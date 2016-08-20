using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonInfusion
{
    public class ConnectionMock : IConnection
    {
        private int[,] labyrinth;
        private Point currentPos, endPos;


        public ConnectionMock(int[,] lab, Point startPos, Point endPos)
        {
            if (lab == null)
                throw new ArgumentNullException();

            labyrinth = lab;
        }


        public bool CheckConnection()
        {
            return true;
        }

        public PositionInfo MoveDown()
        {
            int maxY = labyrinth.GetLength(1) - 1;
            if (currentPos.Y < maxY && labyrinth[currentPos.X, currentPos.Y + 1] == 0)
            {
                currentPos.Y++;
                return new PositionInfo
                {
                    X = currentPos.X,
                    Y = currentPos.Y,
                    Failure = false
                };
            }
            else
            {
                return new PositionInfo
                {
                    Failure = true
                };
            }
        }

        public PositionInfo MoveLeft()
        {
            
            if (currentPos.X > 0 && labyrinth[currentPos.X - 1, currentPos.Y] == 0)
            {
                currentPos.X--;
                return new PositionInfo
                {
                    X = currentPos.X,
                    Y = currentPos.Y,
                    Failure = false
                };
            }
            else
            {
                return new PositionInfo
                {
                    Failure = true
                };
            }
        }

        public PositionInfo MoveRight()
        {
            int maxX = labyrinth.GetLength(0) - 1;
            if (currentPos.X < maxX && labyrinth[currentPos.X + 1, currentPos.Y] == 0)
            {
                currentPos.X++;
                return new PositionInfo
                {
                    X = currentPos.X,
                    Y = currentPos.Y,
                    Failure = false
                };
            }
            else
            {
                return new PositionInfo
                {
                    Failure = true
                };
            }
        }

        public PositionInfo MoveUp()
        {
            if (currentPos.Y > 0 && labyrinth[currentPos.X, currentPos.Y + 1] == 0)
            {
                currentPos.Y++;
                return new PositionInfo
                {
                    X = currentPos.X,
                    Y = currentPos.Y,
                    Failure = false
                };
            }
            else
            {
                return new PositionInfo
                {
                    Failure = true
                };
            }
        }

        public WallsPosition Scan()
        {
            throw new NotImplementedException();
        }

        public WallsPosition ScanDown()
        {
            throw new NotImplementedException();
        }

        public WallsPosition ScanLeft()
        {
            throw new NotImplementedException();
        }

        public WallsPosition ScanRight()
        {
            throw new NotImplementedException();
        }

        public WallsPosition ScanUp()
        {
            throw new NotImplementedException();
        }

        public StartCoordinates StartCompetition()
        {
            return new StartCoordinates
            {
                StartX = currentPos.X,
                StartY = currentPos.Y,
                EndX = endPos.X,
                EndY = endPos.Y
            };
        }
    }
}
