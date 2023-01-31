using MobileClientApp.ViewModels;
using MobileClientApp.Views;
using MobileClientApp.Views.Main;
using MobileClientApp.Views.Main.Order;
using MobileClientApp.Views.Register;

namespace MobileClientApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        this.BindingContext = new AppShellViewModel();

        #region Routing
        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        Routing.RegisterRoute(nameof(ConfirmRegisterPage), typeof(ConfirmRegisterPage));
        Routing.RegisterRoute(nameof(ProceedRegisterPage), typeof(ProceedRegisterPage));
        Routing.RegisterRoute(nameof(OrderPage), typeof(OrderPage));
        Routing.RegisterRoute(nameof(HistoryOrderPage), typeof(HistoryOrderPage));
        Routing.RegisterRoute(nameof(ConfirmOrderPage), typeof(ConfirmOrderPage));
        Routing.RegisterRoute(nameof(DetailOrderPage), typeof(DetailOrderPage));
        Routing.RegisterRoute(nameof(DetailDeliveryPage), typeof(DetailDeliveryPage));
        Routing.RegisterRoute(nameof(MapPage), typeof(MapPage));
        Routing.RegisterRoute(nameof(ActiveDeliveriesPage), typeof(ActiveDeliveriesPage));
        Routing.RegisterRoute(nameof(OnReviewOrdersPage), typeof(OnReviewOrdersPage));
        Routing.RegisterRoute(nameof(WaitingOrdersPage), typeof(WaitingOrdersPage));
        Routing.RegisterRoute(nameof(DriverTrackingPage), typeof(DriverTrackingPage));
        #endregion
	}
}
