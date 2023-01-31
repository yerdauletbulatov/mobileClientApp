using MobileClientApp.ViewModels.Register;

namespace MobileClientApp.Views.Register;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterViewModel model)
	{
		InitializeComponent();
		this.BindingContext = model;
	}
}