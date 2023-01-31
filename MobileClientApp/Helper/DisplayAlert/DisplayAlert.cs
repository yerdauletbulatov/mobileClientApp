
namespace MobileClientApp.Helper.DisplayAlert
{
    public static class DisplayAlert
    {
        public async static void NotCorrect()
        {
            await App.Current.MainPage.DisplayAlert("Ошибка", "Неверное заполнение", "Повторите еще раз");
        }
        public async static void BadSmsCode()
        {
            await App.Current.MainPage.DisplayAlert("Ошибка", "Неверный смс код", "Повторите еще раз");
        }
        public async static void ExceptionMessage(string message)
        {
            await App.Current.MainPage.DisplayAlert("Ошибка", message, "Повторите еще раз");
        }
    }
}
