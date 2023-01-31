using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileClientApp.Helper;
using MobileClientApp.Helper.DisplayAlert;
using MobileClientApp.Helper.Extentions;
using MobileClientApp.Interfaces;
using MobileClientApp.Models.Values;
using MobileClientApp.ViewModels.Base;
using MobileClientApp.Views.Main;
using System.Collections.ObjectModel;


namespace MobileClientApp.ViewModels.Main
{
    public partial class HistoryOrderViewModel : BaseViewModel
    {
        [ObservableProperty]
        private bool _isBusy;
        private readonly INotification notification;

        public HistoryOrderViewModel(INotification notification, HttpClient httpClient) : base(httpClient)
        {
            this.notification = notification;
            IsBusy = false;
        }
        
        public ObservableCollection<DeliveryInfo> DeliveryInfo { get; set; } = new();

        [ICommand]
        async Task CreateOrder()
        {
            await Shell.Current.GoToAsync($"{nameof(OrderPage)}");
        }


        [ICommand]
         async Task Refresh()
        {
            try
            {
                IsBusy = true;

                await Task.Delay(1000);
                DeliveryInfo.Clear();
                var orderIfnolist = await _httpClient.ResponseDataPostAsync<List<DeliveryInfo>>(API.ActiveOrders);
                foreach (var item in orderIfnolist)
                {
                    DeliveryInfo.Add(item);
                }
            }
            catch (Exception ex)
            {
                DisplayAlert.ExceptionMessage(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
