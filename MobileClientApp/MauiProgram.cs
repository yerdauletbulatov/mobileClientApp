using MobileClientApp.Helper;
using MobileClientApp.Interfaces;
using MobileClientApp.Models.Values;
using MobileClientApp.Repositories;
using MobileClientApp.Services;
using MobileClientApp.ViewModels;
using MobileClientApp.ViewModels.Main;
using MobileClientApp.ViewModels.Order;
using MobileClientApp.ViewModels.Register;
using MobileClientApp.Views;
using MobileClientApp.Views.Main;
using MobileClientApp.Views.Main.Order;
using MobileClientApp.Views.Register;

namespace MobileClientApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiMaps()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        //Services
        builder.Services.AddScoped<HttpClient>();
        builder.Services.AddScoped<API>();

        //Hub
        builder.Services.AddSingleton<INotification, Notification>();

        //IStorages
        builder.Services.AddScoped<IStorage<ClientInfo>, AppDataStorage<ClientInfo>>();
        builder.Services.AddScoped<IStorage<ClientAppDataInfo>, AppDataStorage<ClientAppDataInfo>>();

        //Views
        builder.Services.AddScoped<MapPage>();
        builder.Services.AddScoped<DriverTrackingPage>();
        builder.Services.AddTransient<OrderPage>();
        builder.Services.AddTransient<ConfirmOrderPage>();
        builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddTransient<ConfirmRegisterPage>();
        builder.Services.AddTransient<ProceedRegisterPage>();
        builder.Services.AddTransient<HistoryOrderPage>();
        builder.Services.AddTransient<SupportServicePage>();
        builder.Services.AddTransient<ActiveDeliveriesPage>();
        builder.Services.AddTransient<WaitingOrdersPage>();
        builder.Services.AddTransient<DetailOrderPage>();
        builder.Services.AddTransient<DetailDeliveryPage>();
        builder.Services.AddTransient<OnReviewOrdersPage>();

        //View Models
        builder.Services.AddScoped<MapViewModel>();
        builder.Services.AddScoped<DriverTrackingViewModel>();
        builder.Services.AddTransient<OrderViewModel>();
        builder.Services.AddTransient<ConfirmOrderViewModel>();
        builder.Services.AddTransient<RegisterViewModel>();
        builder.Services.AddTransient<ConfirmRegisterViewModel>();
        builder.Services.AddTransient<ProceedRegisterViewModel>();
        builder.Services.AddTransient<HistoryOrderViewModel>();
        builder.Services.AddTransient<SupportServiceViewModel>();
        builder.Services.AddTransient<ActiveDeliveriesViewModel>();
        builder.Services.AddTransient<WaitingOrdersViewModel>();
        builder.Services.AddTransient<DetailOrderViewModel>();
        builder.Services.AddTransient<DetailDeliveryViewModel>();
        builder.Services.AddTransient<OnReviewOrdersViewModel>();

        return builder.Build();
	}
}
