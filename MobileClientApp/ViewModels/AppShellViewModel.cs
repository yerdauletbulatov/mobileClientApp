using CommunityToolkit.Mvvm.Input;
using MobileClientApp.Views.Register;

namespace MobileClientApp.ViewModels
{
    public partial class AppShellViewModel
    {
        [ICommand]
        async void SignOut()
        {
            await Shell.Current.GoToAsync($"{nameof(RegisterPage)}");
        }
    }
}
