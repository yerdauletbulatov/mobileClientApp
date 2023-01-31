using Microsoft.Maui.Maps;
using MobileClientApp.ViewModels;
using Microsoft.Maui.Controls.Maps;
using Location = Microsoft.Maui.Devices.Sensors.Location;
using MobileClientApp.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MobileClientApp.Models.Values;

namespace MobileClientApp.Views;


public partial class MapPage : ContentPage
{
    public MapPage(MapViewModel model)
    {
        InitializeComponent();
        BindingContext = model;
        LayoutMap.Add(model.Map);
    }

    protected async override void OnAppearing()
    {
        await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
    }


}


