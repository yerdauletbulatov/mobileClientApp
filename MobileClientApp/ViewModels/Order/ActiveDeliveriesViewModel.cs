using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileClientApp.Helper;
using MobileClientApp.Helper.DisplayAlert;
using MobileClientApp.Helper.Extentions;
using MobileClientApp.Models.Values;
using MobileClientApp.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MobileClientApp.ViewModels.Order
{
    public partial class ActiveDeliveriesViewModel : BaseViewModel
    {
        [ObservableProperty]
        private bool _isBusy;

        public ActiveDeliveriesViewModel(HttpClient httpClient) : base(httpClient)
        {
            IsBusy = false;
        }

        public ObservableCollection<DeliveryInfo> DeliveriesInfo { get; set; } = new();

        public async void ContentPage_Appearing(object sender, EventArgs e) =>
            await Refresh();

        [ICommand]
        async Task Refresh()
        {
            try
            {
                IsBusy = true;
                await Task.Delay(1000);
                DeliveriesInfo.Clear();
                var orderIfnolist = await _httpClient.ResponseDataPostAsync<List<DeliveryInfo>>(API.ActiveOrders);
                foreach (var item in orderIfnolist)
                {
                    DeliveriesInfo.Add(item);
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
