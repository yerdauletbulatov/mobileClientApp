using CommunityToolkit.Mvvm.ComponentModel;
using MobileClientApp.Models.Values;
using MobileClientApp.ViewModels.Base;

namespace MobileClientApp.ViewModels.Order
{
    public partial class DetailOrderViewModel : BaseViewModel
    {
        [ObservableProperty]
        private OrderInfo orderInfo;
        public DetailOrderViewModel(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
