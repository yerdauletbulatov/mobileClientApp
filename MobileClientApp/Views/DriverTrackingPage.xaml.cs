using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using MobileClientApp.ViewModels;

namespace MobileClientApp.Views;


public partial class DriverTrackingPage : ContentPage
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    private readonly DriverTrackingViewModel _model;
    public DriverTrackingPage(DriverTrackingViewModel model)
	{
        InitializeComponent();
        BindingContext = model;
        _model = model;
    }

    protected async override void OnAppearing()
    {
        Latitude = _model.DeliveryInfo.Location.Latitude;
        Longitude = _model.DeliveryInfo.Location.Longitude;

        Location location = new Location(Latitude, Longitude);
        Pin pin = new Pin
        {
            Label = "Водитель",
            Address = "Водитель",
            Type = PinType.Place,
            Location = location
        };
        mapp.Pins.Add(pin);

        MapSpan mapSpan = new MapSpan(location, 0.01, 0.01);
        mapp.MoveToRegion(mapSpan);

        await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
    }
  
}