using MobileClientApp.ViewModels.Register;

namespace MobileClientApp.Views.Register;

public partial class ProceedRegisterPage : ContentPage
{
	public ProceedRegisterPage(ProceedRegisterViewModel model)
	{
		InitializeComponent();
		this.BindingContext = model;
	}
}