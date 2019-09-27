using System.IO;

namespace RouteFinder
{
    internal class SubwayLoader
    {
        private readonly Subway _subway;

        public SubwayLoader(Subway subway)
        {
            _subway = subway;
        }

        public SubwayLoader()
        {
            _subway = new Subway();
        }

        public Subway LoadFromFile(string subwayFileName)
        {
            var subway = new Subway();

            var file = new StreamReader(subwayFileName);
            var ss = file.ReadLine();
            while (!string.IsNullOrEmpty(ss))
            {
                subway.AddStation(ss);
                ss = file.ReadLine();
            }

            //foreach (var station in subway.GetStations())
            //{
            //    Console.WriteLine("Station:\t {0}", station.StationName);
            //}

            ss = file.ReadLine();

            while (!string.IsNullOrEmpty(ss))
            {
                var lineName = ss;
                var station1Name = file.ReadLine();
                var station2Name = file.ReadLine();

                while (!string.IsNullOrEmpty(station2Name))
                {
                    subway.AddConnection(lineName, station1Name, station2Name);
                    station1Name = station2Name;
                    station2Name = file.ReadLine();
                }

                ss = file.ReadLine();
            }
            //foreach (var connection in subway.GetConnections())
            //{
            //    Console.WriteLine("{0}\t{1}\t{2}", connection.GetLineName(), connection.GeStation1().StationName, connection.GeStation2().StationName);
            //}

            file.Close();

            return subway;
        }
    }
}
