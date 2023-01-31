using MobileClientApp.ViewModels.Register;

namespace MobileClientApp.Views.Register;

public partial class ConfirmRegisterPage : ContentPage
{
	public ConfirmRegisterPage(ConfirmRegisterViewModel model)
	{
		InitializeComponent();
		this.BindingContext = model;
	}
}