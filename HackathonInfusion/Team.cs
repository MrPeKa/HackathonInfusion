namespace HackathonInfusion
{
    public class Team
    {
        public string teamId { get; set; }

        public string mazeId { get; set; }

        public Team(string teamId, string mazeId)
        {
            this.teamId = teamId;
            this.mazeId = mazeId;
        }

        public object GetJson()
        {
            return this;
        }
    }
}
