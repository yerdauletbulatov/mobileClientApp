using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileClientApp.Helper;
using MobileClientApp.Helper.DisplayAlert;
using MobileClientApp.Helper.Extentions;
using MobileClientApp.Models.Values;
using MobileClientApp.ViewModels.Base;
using MobileClientApp.Views.Register;


namespace MobileClientApp.ViewModels.Register
{
    public partial class RegisterViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _phoneNumber;
        [ObservableProperty]
        private bool _isRunning;
        public RegisterViewModel(HttpClient httpClient) : base(httpClient)
        {
        }

        [ICommand]
        async void Register()
        {
            IsRunning = true;
            try
            {
                Preferences.Clear();
                Preferences.Set(nameof(ClientInfo.PhoneNumber), PhoneNumber);
                await _httpClient.ResponseDataPostAsync(API.Register, new RegisterClient(_phoneNumber));
                await Shell.Current.GoToAsync($"{nameof(ConfirmRegisterPage)}");
            }
            catch (Exception ex)
            {
                DisplayAlert.ExceptionMessage(ex.Message);
            }
            finally
            {
                IsRunning = false;
            }
        }
    }

}
