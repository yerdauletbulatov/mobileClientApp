using MobileClientApp.Models.Base;
using MobileClientApp.Models.Enitities;
using Location = MobileClientApp.Models.Enitities.Location;

namespace MobileClientApp.Models.Values
{
    public class OrderInfo : BaseModel
    {
        public int ClientPackageId { get; set; }
        public City StartCity { get; set; }
        public City FinishCity { get; set; }
        public Package Package { get; set; }
        public CarType CarType { get; set; }
        public bool IsSingle { get; set; }
        public decimal Price { get; set; }
        public string ClientPhoneNumber { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public Location Location { get; set; }
        public string StateName { get; set; }
    }
}
