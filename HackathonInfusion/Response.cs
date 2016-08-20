using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonInfusion
{
    public class Response
    {
        public Position position { get; set; }
        public string details { get; set; }
        public string outcome { get; set; }

        public bool GetFailure()
        {
            if (outcome == "failure")
                return true;
            return false;
        }
    }
}
