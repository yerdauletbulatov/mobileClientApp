using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileClientApp.Models.Values
{
    public class LocationCommand
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string DriverName { get; set; }
        public string DriverSurname { get; set; }
        public string DriverPhoneNumber { get; set; }
    }
}
