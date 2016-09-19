using System;
using System.Collections.Generic;
using System.Linq;


namespace RouteFinder
{
    class Subway
    {
        private readonly List<Station> _stations;
        private readonly List<Connection> _connections;
        private readonly Dictionary<string, List<string>> _network;

        public Subway(List<Station> stations, List<Connection> connections)
        {
            _stations = stations;
            _connections = connections;
            _network = new Dictionary<string, List<string>>();
        }

        public Subway()
        {
            _network = new Dictionary<string, List<string>>();
            _stations=new List<Station>();
            _connections=new List<Connection>();
        }

        public List<Station> GetStations()
        {
            return _stations;
        }

        public List<Connection> GetConnections()
        {
            return _connections;
        }

        public bool HasStation(string stationName)
        {
            //return _stations.Contains(new Station(stationName));
            return _stations.Any(station => stationName == station.StationName);
        }

        public bool HasConnection(string lineName, string station1Name, string station2Name)
        {
            //return _connections.Contains(new Connection(lineName,station1Name,station2Name));
            return _connections.Any(x => x.GetLineName() == lineName && x.GeStation1().StationName == station1Name && x.GeStation2().StationName == station2Name);
        }

        public void AddStation(string stationName)
        {
            var station = new Station(stationName);
            _stations.Add(station);
        }

        public void AddConnection(string lineName, string station1Name, string station2Name)
        {
            if (HasStation(station1Name) && HasStation(station2Name))
            {

                var connection = new Connection(lineName, station1Name, station2Name);
                _connections.Add(connection);
                AddToNetwork(station1Name, station2Name); 
                AddToNetwork(station2Name, station1Name);
            }
            else
            {
                Console.WriteLine("Invalid connection!");
            }
        }

        private void AddToNetwork(string station1Name, string station2Name)
        {
            //var station1 = new Station(station1Name);
            //var station2 = new Station(station2Name);

            if (_network.ContainsKey(station1Name))
            {
                var connectingStations =  _network[station1Name];
                for (var i = 0; i < connectingStations.Count; i++)
                {
                    var connectingStation = connectingStations[i];
                    if (connectingStation == station2Name) continue;
                    connectingStations.Add(station2Name);
                }
            }
            else
            {
                var connectingStations = new List<string> {station2Name};
                _network.Add(station1Name, connectingStations); 
            }

        }

        public List<Connection> GetDirections(string station1Name, string station2Name)
        {
            var route = new List<Connection>();
            
            if (!HasStation(station1Name) || !HasStation(station2Name))
            {
                Console.WriteLine("Invalid Start or End Station!");
                return null;
            }

            //Dijkstra algorithm
            var start = station1Name;
            var end = station2Name;
            var reachableStations = new List<string>();
            var neighbors = _network[start]; 
            var previousStations= new Dictionary<string,string>();
            
            foreach (var neighbor in neighbors)
            {
                if (neighbor==end)
                {
                    route.Insert(0,FindConnection(start,end));
                    return route;
                }
                reachableStations.Add(neighbor);
                previousStations.Add(neighbor,start);
            }
            
            var nextStations = neighbors.ToList();

            
            for (var i=1; i < _stations.Count; i++)
            {
                var tmpNextStations=new List<string>();
                foreach (var nextStation in nextStations)
                {
                    //Console.WriteLine(" {0}",  nextStation);
                    //reachableStations.Add(nextStation);
                    var currentStation = nextStation;
                    var currentNeighbors = _network[currentStation];
                    foreach (var currentNeighbor in currentNeighbors)
                    {
                        if(currentNeighbor==start) continue;
                        //Console.WriteLine("{1} currentNeighbor: {0}", currentNeighbor,nextStation);
                        if (currentNeighbor==end)
                        {
                            reachableStations.Add(currentNeighbor);
                            previousStations.Add(currentNeighbor,currentStation);
                            goto exitLoop;
                        }
                        if (reachableStations.Contains(currentNeighbor)) continue;
                        reachableStations.Add(currentNeighbor);
                        tmpNextStations.Add(currentNeighbor);
                        previousStations.Add(currentNeighbor,currentStation);
                    }
                }
                nextStations = tmpNextStations; 
            }
        exitLoop:
            // we have found the path by now. exit Dijkstra algorithm
            var keepLooping = true;
            var keyStation = end;
            while (keepLooping)
            {
                if (keyStation == null) continue;
                var station = previousStations[keyStation];
                if (station != null) route.Insert(0,FindConnection(station,keyStation));
                if (start==station)
                {
                    keepLooping = false;
                }
                keyStation = station;
            }
            return route; 

        }

        private Connection FindConnection(string station1Name, string station2Name)
        {
            foreach (var connection in _connections)
            {
                var one = connection.GeStation1();
                var two = connection.GeStation2();
                if (station1Name==one.StationName && station2Name==two.StationName) return connection;
            }
            return null;
        }

    }


}
