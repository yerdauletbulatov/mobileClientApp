using MobileClientApp.Models.Values;

namespace MobileClientApp.Controls;

public partial class FlyoutHeaderControl : StackLayout
{
	public FlyoutHeaderControl()
	{
		InitializeComponent();
        lblUserName.Text = Preferences.Get(nameof(ClientInfo.Name), string.Empty);
        lblUserSurname.Text = Preferences.Get(nameof(ClientInfo.Surname), string.Empty);
        lblUserPhoneNumber.Text = Preferences.Get(nameof(ClientInfo.PhoneNumber), string.Empty);
    }
}