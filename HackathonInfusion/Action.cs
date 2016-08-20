using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HackathonInfusion
{
    class Action
    {
        public string Type { get; set; }
        public Team postDetails { get; set; }

        public Action(ActionType actionType, Team details)
        {
            Type = actionType.ToString();
            postDetails = details;
        }

        public object GetJsonActionToPost()
        {
            return postDetails;
        }
    }
}
