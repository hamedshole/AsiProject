namespace Asi.Model.ValueObjects
{
    public class ControlLocation
    {
        public double Longtitude { get; set; }
        public double Latitude { get; set; }

        public ControlLocation(double longtitude, double latitude)
        {
            Longtitude = longtitude;
            Latitude = latitude;
        }
    }
}
