﻿using System;
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
            currentPos = startPos;
            this.endPos = endPos;
        }


        public bool CheckConnection()
        {
            return true;
        }

        public PositionInfo MoveDown()
        {
            Console.WriteLine("MoveDown");
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
            Console.WriteLine("MoveLeft");
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
            Console.WriteLine("MoveRight");
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
            Console.WriteLine("MoveUp");
            if (currentPos.Y > 0 && labyrinth[currentPos.X, currentPos.Y - 1] == 0)
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
            Console.WriteLine("Scan");
            var curX = currentPos.X;
            var curY = currentPos.Y;
            return new WallsPosition
            {
                NorthWallDistance = labyrinth[curX, curY - 1],
                SouthWallDistance = labyrinth[curX, curY + 1],
                WestWallDistance = labyrinth[curX - 1, curY],
                EastWallDistance = labyrinth[curX + 1, curY]
            };
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
