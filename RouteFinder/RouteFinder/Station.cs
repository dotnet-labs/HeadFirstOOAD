using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteFinder
{
    class Station
    {
        public string StationName { get; set; }
        //public List<int> ConnectedStations;

        public Station(string stationName)
        {
            StationName = stationName;
        }
        
        public bool Equals(Station otherstation)
        {
            return StationName == otherstation.StationName;
        }
        
    }
}
