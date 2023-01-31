using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileClientApp.Helper;
using MobileClientApp.Helper.DisplayAlert;
using MobileClientApp.Helper.Extentions;
using MobileClientApp.Models.Values;
using MobileClientApp.ViewModels.Base;

namespace MobileClientApp.ViewModels.Order
{
    public partial class OnReviewOrdersViewModel : BaseViewModel
    {
        [ObservableProperty]
        private bool _isBusy;

        public OnReviewOrdersViewModel(HttpClient httpClient) : base(httpClient)
        {
            IsBusy = false;
        }

        public ObservableCollection<OrderInfo> OnReviewOrders { get; set; } = new();

        public async void ContentPage_Appearing(object sender, EventArgs e) =>
           await Refresh();

        [ICommand]
        async Task Refresh()
        {
            try
            {
                IsBusy = true;
                await Task.Delay(1000);
                this.OnReviewOrders.Clear();
                var onReviewOrders = await _httpClient.ResponseDataPostAsync<List<OrderInfo>>(API.OnReviewOrders);
                onReviewOrders.ForEach(c => this.OnReviewOrders.Add(c));
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
