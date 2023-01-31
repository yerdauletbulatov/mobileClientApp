using MobileClientApp.Models.Base;

namespace MobileClientApp.Models.Values
{
    public class ConfirmRegister : BaseModel
    {
        public string PhoneNumber { get; set; }
        public string SmsCode { get; set; }
    }
}
