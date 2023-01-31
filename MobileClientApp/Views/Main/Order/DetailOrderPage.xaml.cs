using MobileClientApp.ViewModels.Order;

namespace MobileClientApp.Views.Main.Order;

public partial class DetailOrderPage : ContentPage
{
	public DetailOrderPage(DetailOrderViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}