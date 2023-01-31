using MobileClientApp.ViewModels.Base;

namespace MobileClientApp.ViewModels.Main
{
    public partial class SupportServiceViewModel : BaseViewModel
    {
        public SupportServiceViewModel(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
