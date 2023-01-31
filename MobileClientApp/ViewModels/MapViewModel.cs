using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Map = Microsoft.Maui.Controls.Maps.Map;
using MapSpan = Microsoft.Maui.Maps.MapSpan;
using MobileClientApp.Models.Values;
using MobileClientApp.ViewModels.Base;
using MobileClientApp.Views.Main;
using MobileClientApp.Interfaces;
using Microsoft.Maui.Controls.Maps;

namespace MobileClientApp.ViewModels
{
    public partial class MapViewModel : BaseViewModel
    { 

        private readonly CancellationToken cancellationToken = new();
        private readonly INotification notification;
        public Map Map = new(new MapSpan(new Location(43.2146, 76.85), 0.1, 0.1)) { IsShowingUser = true };
        public MapViewModel(INotification notification, HttpClient httpClient) : base(httpClient)
        {
            this.notification = notification;
            SetLocation();
        }
        public void MoveToRegion(string phoneNumber)
        {
                var pin = Map.Pins.FirstOrDefault(p => p.Address == phoneNumber);
                MapSpan mapSpan = new MapSpan(pin.Location, 0.01, 0.01);
                Map.MoveToRegion(mapSpan);
        }
        private async void SetLocation()
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var location = await notification.DequeueAsync(cancellationToken);
                if (location is null) continue;
                var pin = Map.Pins.FirstOrDefault(p => p.Address == location.DriverPhoneNumber);
                if (pin != null)
                {
                    Map.Pins.Remove(pin);
                    pin.Location = new Location(location.Latitude, location.Longitude);
                    Map.Pins.Add(pin);
                }
                else
                {
                    SetPin(location);
                }
            }
        }

        [ICommand]
        async Task CreateOrder()
        {
            await Shell.Current.GoToAsync($"{nameof(OrderPage)}");
        }

        private Pin SetPin(LocationCommand location)
        {
            var pin = new Pin
            {
                Label = location.DriverName ?? "Водитель",
                Address = location.DriverPhoneNumber,
                Type = PinType.Place,
                Location = new Location(location.Latitude, location.Longitude)
             };
            Map.Pins.Add(pin);
            return pin;
        }
    }
}
