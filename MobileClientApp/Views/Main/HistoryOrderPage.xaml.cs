using MobileClientApp.ViewModels.Main;

namespace MobileClientApp.Views.Main;

public partial class HistoryOrderPage : ContentPage
{
	public HistoryOrderPage(HistoryOrderViewModel model)
	{
		InitializeComponent();
		this.BindingContext = model;
	}
}