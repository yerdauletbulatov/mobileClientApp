using MobileClientApp.Models.Values;
using MobileClientApp.ViewModels.Order;

namespace MobileClientApp.Views.Main.Order;

public partial class WaitingOrdersPage : ContentPage
{
	private readonly DetailOrderViewModel _viewModel;

    public WaitingOrdersPage(WaitingOrdersViewModel viewModel, DetailOrderViewModel detailOrderViewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		_viewModel = detailOrderViewModel;
        WaitingOrders.Appearing += viewModel.Item_Appearing;
    }

	private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
	{
		var orderInfo = e.Item as OrderInfo;
		if (orderInfo is not null)
		{
			_viewModel.OrderInfo = orderInfo;
			await Navigation.PushAsync(new DetailOrderPage(_viewModel));
		}
		
	}
}