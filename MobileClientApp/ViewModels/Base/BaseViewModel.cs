using CommunityToolkit.Mvvm.ComponentModel;

namespace MobileClientApp.ViewModels.Base
{
    public abstract class BaseViewModel : ObservableObject
    {
        protected readonly HttpClient _httpClient;
        public BaseViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
