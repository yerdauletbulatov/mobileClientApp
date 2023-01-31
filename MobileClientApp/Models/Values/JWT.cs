using MobileClientApp.Models.Base;

namespace MobileClientApp.Models.Values
{
    public class JWT : BaseModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public JWT(string refreshToken, string accessToken = "")
        {
            RefreshToken = refreshToken;
            AccessToken = accessToken;
        }
        public JWT()
        {
        }
    }
}
