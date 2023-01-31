using Microsoft.Maui.Controls;
using MobileClientApp.Models;
using MobileClientApp.Views;
using MobileClientApp.Views.Main;
using MobileClientApp.Views.Main.Order;

namespace MobileClientApp.Controls.ModelControl
{
    public class AppConstant
    {
        public async static Task AddFlyoutMenusDetails()
        {
            if (AppShell.Current.FlyoutHeader is null)
            {
                AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
                var MapPageInfo = AppShell.Current.Items.Where(f => f.Route == nameof(MapPage)).FirstOrDefault();
                if (MapPageInfo != null) AppShell.Current.Items.Remove(MapPageInfo);

                var flyoutItem = new FlyoutItem()
                {
                    Route = nameof(MapPage),
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Items =
                    {
                        new ShellContent
                        {
                            Icon = Icons.Dashboard,
                            Title = "Главная",
                            ContentTemplate = new DataTemplate(typeof(MapPage)),
                        }
                    }
                };

                var flyoutItem2 = new FlyoutItem()
                {
                    Icon = Icons.Dashboard,
                    Title = "Заказы",
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsSingleItem,
                    Items =
                {
                    new ShellContent
                    {
                        Icon = Icons.CarIcon,
                        Title = "Активные",
                        ContentTemplate = new DataTemplate(typeof(ActiveDeliveriesPage))
                    },
                    new ShellContent
                    {
                        Icon = Icons.CarIcon,
                        Title = "Ожидающие",
                        ContentTemplate = new DataTemplate(typeof(WaitingOrdersPage))
                    },
                    new ShellContent
                    {
                        Icon = Icons.CarIcon,
                        Title = "На Рассмотрении",
                        ContentTemplate = new DataTemplate(typeof(OnReviewOrdersPage))
                    }
                }
                };

                var flyoutItem3 = new FlyoutItem()
                {
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Items =
                {
                    new ShellContent
                    {
                        Icon = Icons.AboutUs,
                        Title = "История заказов",
                        ContentTemplate = new DataTemplate(typeof(HistoryOrderPage))
                    },
                    new ShellContent
                    {
                        Icon = Icons.AboutUs,
                        Title = "Служба поддержки",
                        ContentTemplate = new DataTemplate(typeof(SupportServicePage)),
                    }
                }
                };

                AppShell.Current.Items.Add(flyoutItem);
                AppShell.Current.Items.Add(flyoutItem2);
                AppShell.Current.Items.Add(flyoutItem3);
            }
                await Shell.Current.GoToAsync($"//{nameof(MapPage)}");
        }
    }
}
