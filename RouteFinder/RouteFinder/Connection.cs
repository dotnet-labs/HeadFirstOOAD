using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteFinder
{
    class Connection
    {
        private readonly string _lineName;
        private readonly Station _station1;
        private readonly Station _station2;

        public Connection(string lineName, string station1Name, string station2Name)
        {
            _lineName = lineName;
            _station1 = new Station(station1Name);
            _station2 = new Station(station2Name);
        }

        public string GetLineName()
        {
            return _lineName;
        }

        public Station GeStation1()
        {
            return _station1;
        }

        public Station GeStation2()
        {
            return _station2;
        }

        

    }
}
