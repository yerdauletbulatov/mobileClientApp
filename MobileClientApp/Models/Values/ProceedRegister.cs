using MobileClientApp.Models.Base;

namespace MobileClientApp.Models.Values
{
    public class ProceedRegister : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
    }
}
