using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonInfusion
{
    class Action
    {
        public ActionType ActionType { get; set; }
        public Team Team { get; set; }
        public Maze Maze { get; set; }

        public Action(ActionType actionType, Team team, Maze maze)
        {
            ActionType = actionType;
            Team = team;
            Maze = maze;
        }
    }
}
