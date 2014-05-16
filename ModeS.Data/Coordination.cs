namespace ModeS.Data
{
    public struct Coordination
    {
        public double Lat { get; private set; }

        public double Lon { get; private set; }

        public Coordination(double lat, double lon)
            : this()
        {
            Lat = lat;
            Lon = lon;
        } 
    }
}