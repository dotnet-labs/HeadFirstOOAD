using System;
using System.Collections.Generic;
using System.IO;

namespace RouteFinder
{
    internal class SubwayPrinter
    {
        private StringWriter _output;

        public SubwayPrinter(StringWriter output)
        {
            _output = output;  
        }

        public void PrintDirections(List<Connection> route)
        {
            var connection = route[0];
            var currentLineName = connection.GetLineName();
            var previousLineName = currentLineName;
            Console.WriteLine("Start out at {0}.", connection.GeStation1().StationName);
            Console.WriteLine("Get on the {0} heading towards {1}.", currentLineName, connection.GeStation2().StationName);
            for (var i = 1; i < route.Count; i++)
            {
                connection = route[i];
                currentLineName = connection.GetLineName();
                if (currentLineName == previousLineName)
                {
                    Console.WriteLine(" Continue past {0} ...", connection.GeStation1().StationName);
                }
                else
                {
                    Console.WriteLine("When you get to {0}, get off the {1}.",connection.GeStation1().StationName,previousLineName);
                    Console.WriteLine("Switch over to the {0}, heading towards {1}.",currentLineName,connection.GeStation2().StationName);
                    previousLineName = currentLineName;
                }
            }
            Console.WriteLine("Get off at {0} and enjoy yourself!", connection.GeStation2().StationName);
        }
    }
}
