using MobileClientApp.Models.Values;
using MobileClientApp.ViewModels.Order;

namespace MobileClientApp.Views.Main.Order;

public partial class ActiveDeliveriesPage : ContentPage
{
    private readonly DetailDeliveryViewModel _viewModel;
    public ActiveDeliveriesPage(ActiveDeliveriesViewModel viewModel, DetailDeliveryViewModel detailDeliveryViewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        _viewModel = detailDeliveryViewModel;
        ActiveDeliveries.Appearing += viewModel.ContentPage_Appearing;
    }
    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var deliveryInfo = e.Item as DeliveryInfo;
        if (deliveryInfo is not null)
        {
            _viewModel.DeliveryInfo = deliveryInfo;
            await Navigation.PushAsync(new DetailDeliveryPage(_viewModel));
        }
    }
}