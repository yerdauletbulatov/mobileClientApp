using MobileClientApp.Models.Values;

namespace MobileClientApp.Helper
{
    public class API
    {
        private static readonly string _host = "http://172.31.208.1:5000";
        public readonly Dictionary<string, string> _apiKey = new()
        {
            { nameof(ClientAppDataInfo), _host + "/api/client/appData" },
            { nameof(ClientInfo), _host + "/api/userData" }
        };
        public static string Hub => _host + "/api/notification";
        public static string RefreshAccess => _host + "/api/refreshToken";
        public static string Register => _host + "/api/register";
        public static string ConfirmRegister => _host + "/api/confirmRegister";
        public static string ProceedRegister => _host + "/api/proceedRegister";  
        public static string Calculate => _host + "/api/client/calculate";
        public static string CreateOrder => _host + "/api/client/createOrder";
        public static string ActiveOrders => _host + "/api/client/activeOrders";
        public static string OnReviewOrders => _host + "/api/client/onReviewOrders";
        public static string WaitingOrders => _host + "/api/client/waitingOrders";
    }
}
