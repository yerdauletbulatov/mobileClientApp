using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileClientApp.Controls.ModelControl;
using MobileClientApp.Helper;
using MobileClientApp.Helper.DisplayAlert;
using MobileClientApp.Helper.Extentions;
using MobileClientApp.Models.Values;
using MobileClientApp.ViewModels.Base;
using MobileClientApp.Views.Register;

namespace MobileClientApp.ViewModels.Register
{
    public partial class ConfirmRegisterViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _smsCode;
        [ObservableProperty]
        private bool _isRunning;
        public ConfirmRegisterViewModel(HttpClient httpClient) : base(httpClient)
        {
        }

        [ICommand]
        async Task ConfirmRegister()
        {
            try
            {
                IsRunning = true;
                var clientInfo = await _httpClient.ResponseDataPostAsync(API.ConfirmRegister, new ClientInfo(Preferences.Get(nameof(ClientInfo.PhoneNumber), string.Empty), SmsCode));
                Preferences.Set(nameof(JWT.AccessToken), clientInfo.AccessToken);
                Preferences.Set(nameof(JWT.RefreshToken), clientInfo.RefreshToken);
                if (clientInfo.IsValid)
                {
                    Preferences.Set(nameof(ClientInfo.Name), clientInfo.Name);
                    Preferences.Set(nameof(ClientInfo.Surname), clientInfo.Surname);
                    await AppConstant.AddFlyoutMenusDetails();
                }
                else
                {
                    await Shell.Current.GoToAsync($"{nameof(ProceedRegisterPage)}");
                }
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
