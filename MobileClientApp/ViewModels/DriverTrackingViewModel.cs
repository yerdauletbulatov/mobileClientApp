using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileClientApp.Models.Values;
using MobileClientApp.ViewModels.Base;
using MobileClientApp.Views.Main;

namespace MobileClientApp.ViewModels
{
    [QueryProperty("DeliveryInfo", "DeliveryInfo")]
    public partial class DriverTrackingViewModel : BaseViewModel
    {
        [ObservableProperty]
        public DeliveryInfo deliveryInfo;

        public DriverTrackingViewModel(HttpClient httpClient) : base(httpClient)
        {
        }

        [ICommand]
        async Task CreateOrder()
        {
            await Shell.Current.GoToAsync($"{nameof(OrderPage)}");
        }   
    }
}
