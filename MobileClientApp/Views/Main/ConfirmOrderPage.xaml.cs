using MobileClientApp.ViewModels.Main;

namespace MobileClientApp.Views.Main;

public partial class ConfirmOrderPage : ContentPage
{
	public ConfirmOrderPage(ConfirmOrderViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}