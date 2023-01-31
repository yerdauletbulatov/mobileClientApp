using MobileClientApp.Models.Base;

namespace MobileClientApp.Models.Enitities
{
    public class Location : BaseModel
    {
        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
    }
}
