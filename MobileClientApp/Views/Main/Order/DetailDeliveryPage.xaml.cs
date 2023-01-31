using MobileClientApp.ViewModels.Order;

namespace MobileClientApp.Views.Main.Order;

public partial class DetailDeliveryPage : ContentPage
{
	public DetailDeliveryPage(DetailDeliveryViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}