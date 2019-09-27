namespace RouteFinder
{
    internal class Station
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
