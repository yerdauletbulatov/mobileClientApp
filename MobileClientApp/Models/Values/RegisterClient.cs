using MobileClientApp.Models.Base;

namespace MobileClientApp.Models.Values
{
    public class RegisterClient : BaseModel
    {
        public string PhoneNumber { get; set; }
        public RegisterClient(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    }
}
