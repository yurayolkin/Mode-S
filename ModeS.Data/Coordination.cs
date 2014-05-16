namespace ModeS.Data
{
    public struct Coordination
    {
        public double Lat { get; private set; }

        public double Lng { get; private set; }

        public Coordination(double lat, double lng)
            : this()
        {
            Lat = lat;
            Lng = lng;
        } 
    }
}