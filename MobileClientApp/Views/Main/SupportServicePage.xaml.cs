using MobileClientApp.ViewModels.Main;

namespace MobileClientApp.Views.Main;

public partial class SupportServicePage : ContentPage
{
	public SupportServicePage(SupportServiceViewModel model)
	{
		InitializeComponent();
		this.BindingContext = model;
	}
}