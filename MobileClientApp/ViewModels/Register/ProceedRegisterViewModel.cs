using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileClientApp.Controls.ModelControl;
using MobileClientApp.Helper;
using MobileClientApp.Helper.DisplayAlert;
using MobileClientApp.Helper.Extentions;
using MobileClientApp.Models.Values;
using MobileClientApp.ViewModels.Base;

namespace MobileClientApp.ViewModels.Register
{
    public partial class ProceedRegisterViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _surname;
        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private bool _isRunning;
        public string PhoneNumber => Preferences.Get(nameof(ClientInfo.PhoneNumber), string.Empty);
        public ProceedRegisterViewModel(HttpClient httpClient) : base(httpClient)
        {
        }

        [ICommand]
        async Task ProceedRegister()
        {
            try
            {
                IsRunning = true;
                var clientInfo = await _httpClient.ResponseDataPostAsync(API.ProceedRegister, new ClientInfo(PhoneNumber, Name, Surname));
                Preferences.Set(nameof(ClientInfo.Name), clientInfo.Name);
                Preferences.Set(nameof(ClientInfo.Surname), clientInfo.Surname);
                await AppConstant.AddFlyoutMenusDetails();
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
