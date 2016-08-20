using System.Security.Cryptography.X509Certificates;

namespace HackathonInfusion
{
    public interface IConnection
    {
        StartCoordinates StartCompetition();
        PositionInfo MoveUp();
        PositionInfo MoveDown();
        PositionInfo MoveLeft();
        PositionInfo MoveRight();

        WallsPosition Scan();
        WallsPosition ScanLeft();
        WallsPosition ScanRight();
        WallsPosition ScanUp();
        WallsPosition ScanDown();

        bool CheckConnection();

    }
}