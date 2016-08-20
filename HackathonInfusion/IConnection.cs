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

        // ewentualnie
        // GreetTeam
        bool CheckConnection();

    }
}