using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonInfusion
{
    public class Solver
    {
        private IConnection _connection;

        public Solver(IConnection conn)
        {
            if (conn == null)
                throw new ArgumentNullException("Connection null");

            _connection = conn;
        }


    }
}
