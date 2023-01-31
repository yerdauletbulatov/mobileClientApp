using MobileClientApp.ViewModels.Main;

namespace MobileClientApp.Views.Main;

public partial class OrderPage : ContentPage
{
	public OrderPage(OrderViewModel model)
	{
		InitializeComponent();
		this.BindingContext = model;
    }
}