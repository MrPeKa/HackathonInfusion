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
            throw new NotImplementedException();
        }

        public PositionInfo MoveLeft()
        {
            throw new NotImplementedException();
        }

        public PositionInfo MoveRight()
        {
            throw new NotImplementedException();
        }

        public PositionInfo MoveUp()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
