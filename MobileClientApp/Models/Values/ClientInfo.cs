using MobileClientApp.Models.Base;

namespace MobileClientApp.Models.Values
{
    public class ClientInfo : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsValid { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string SmsCode { get; set; }

        public ClientInfo(string phoneNumber, string smsCode)
        {
            PhoneNumber = phoneNumber;
            SmsCode = smsCode;
        }
        public ClientInfo(string phoneNumber, string name, string surname)
        {
            PhoneNumber = phoneNumber;
            Name = name;
            Surname = surname;
        }
        public ClientInfo()
        {
        }
    }
}
