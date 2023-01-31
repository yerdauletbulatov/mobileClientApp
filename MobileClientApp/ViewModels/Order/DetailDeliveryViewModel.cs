using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileClientApp.Models.Values;
using MobileClientApp.ViewModels.Base;
using MobileClientApp.Views;

namespace MobileClientApp.ViewModels.Order
{
    public partial class DetailDeliveryViewModel : BaseViewModel
    {
        [ObservableProperty]
        private DeliveryInfo deliveryInfo;
        private readonly MapViewModel mapViewModel;
        public DetailDeliveryViewModel(MapViewModel mapViewModel, HttpClient httpClient) : base(httpClient)
        {
            this.mapViewModel = mapViewModel;
        }

        [ICommand]
        async Task Track()
        {
            await Shell.Current.GoToAsync($"{nameof(MapPage)}");
            mapViewModel.MoveToRegion(deliveryInfo.DriverPhoneNumber);
        }

    }
}
