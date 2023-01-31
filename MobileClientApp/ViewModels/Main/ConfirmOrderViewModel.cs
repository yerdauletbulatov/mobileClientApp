using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileClientApp.Helper;
using MobileClientApp.Helper.DisplayAlert;
using MobileClientApp.Helper.Extentions;
using MobileClientApp.Interfaces;
using MobileClientApp.Models.Values;
using MobileClientApp.ViewModels.Base;

namespace MobileClientApp.ViewModels.Main
{
    [QueryProperty("OrderInfo", "OrderInfo")]
    public partial class ConfirmOrderViewModel : BaseViewModel
    {
        private readonly INotification _notification;

        public ConfirmOrderViewModel(INotification notification, HttpClient httpClient) : base(httpClient)
        {
            _notification = notification;
        }

        [ObservableProperty]
        private OrderInfo _orderInfo;

        [ICommand]
        private async Task ConfirmOrder()
        {
            try
            {
                await _httpClient.ResponseDataPostAsync(API.CreateOrder, _orderInfo);
                await Shell.Current.GoToAsync($"../..");
            }
            catch (Exception ex)
            {
                DisplayAlert.ExceptionMessage(ex.Message);
            }
        }

    }
}
