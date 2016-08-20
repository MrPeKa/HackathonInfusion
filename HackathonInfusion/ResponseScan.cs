using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonInfusion
{
    class ResponseScan
    {
        public string left { get; set; }
        public string right { get; set; }
        public string up { get; set; }
        public string down { get; set;  }

        private int GetNumberOfSpace(string wall)
        {
            var counter = 0;
            if (!wall.Equals(""))
            {

                for (int i = 0; i < wall.Length; i++)
                    if (wall[i] != '#')
                        counter++;
            }
            return counter;
        }

        public int GetLeft()
        {
            return GetNumberOfSpace(left);
        }
        public int GetRight()
        {
            return GetNumberOfSpace(right);
        }
        public int GetUp()
        {
            return GetNumberOfSpace(up);
        }
        public int GetDown()
        {
            return GetNumberOfSpace(down);
        }
    }
}
