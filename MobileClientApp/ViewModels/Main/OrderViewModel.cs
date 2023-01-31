using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileClientApp.Helper;
using MobileClientApp.Helper.DisplayAlert;
using MobileClientApp.Helper.Extentions;
using MobileClientApp.Interfaces;
using MobileClientApp.Models.Values;
using MobileClientApp.ViewModels.Base;
using MobileClientApp.Views.Main;
using System.Collections.ObjectModel;
using MobileClientApp.Models.Enitities;
using Location = MobileClientApp.Models.Enitities.Location;

namespace MobileClientApp.ViewModels.Main
{
    public partial class OrderViewModel : BaseViewModel
    {
        private readonly IStorage<ClientAppDataInfo> _appStorage;

        [ObservableProperty]
        private CarType _carType;
        [ObservableProperty]
        private City _startCity;
        [ObservableProperty]
        private City _finishCity;
        [ObservableProperty]
        private Package _package;
        [ObservableProperty]
        private DateTime _date;
        [ObservableProperty]
        private bool _isSingle;
        [ObservableProperty]
        private bool _isHand;
        [ObservableProperty]
        private double _length;
        [ObservableProperty]
        private double _width;
        [ObservableProperty]
        private double _height;
        [ObservableProperty]
        private double _weight;
        [ObservableProperty]
        private bool _isRunning;
        //[ObservableProperty]
        //private TimeOnly _time;
        public ObservableCollection<CarType> CarTypeList { get; private set; }
        public ObservableCollection<City> CityList { get; private set; }
        public ObservableCollection<Package> PackageList { get; private set; }
        public OrderViewModel(HttpClient httpClient, IStorage<ClientAppDataInfo> appStorage) : base(httpClient)
        {
            Weight = 20;
            Date = DateTime.Now;
            _appStorage = appStorage;
            CarTypeList = new ObservableCollection<CarType>(_appStorage.GetData().CarTypes);
            CityList = new ObservableCollection<City>(_appStorage.GetData().Cities);
            PackageList = new ObservableCollection<Package>(App.PackageList);
        }
        [ICommand]
        public async Task CreateOrder()
        {
            try
            {
                IsRunning = true;
                if (CorrectData())
                {
                    var clientLocation = await GetClientLocation();
                    var orderInfo = new OrderInfo()
                    {
                        Package = GetPackage(),
                        StartCity = StartCity,
                        FinishCity = FinishCity,
                        DeliveryDate = Date,
                        CarType = CarType,
                        IsSingle = IsSingle,
                        Price = 0,
                        Location = clientLocation
                    };
                    orderInfo = await _httpClient.ResponseDataPostAsync(API.Calculate, orderInfo);
                    await Shell.Current.GoToAsync($"{nameof(ConfirmOrderPage)}",
                    new Dictionary<string, object>
                    {
                        ["OrderInfo"] = orderInfo
                    });
                }
                else
                {
                    DisplayAlert.NotCorrect();
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
        async Task<Location> GetClientLocation()
        {
            try
            {
                var clientLocation = await Geolocation.GetLocationAsync();
                return new Location(clientLocation.Latitude, clientLocation.Longitude);
            }
            catch
            {
                return null;
            }
        }
        private Package GetPackage()
        {
            if (!IsHand)
            {
                Package.Weight = Weight;
                return Package;
            }
            return new Package()
                    {
                        Name = "Динамичный",
                        Length = Length,
                        Width = Width,
                        Height = Height,
                        Weight = Weight,
                    };
        }
        private bool CorrectData()
        {
            var result = StartCity is null || FinishCity is null || CarType is null;
            if (IsHand)
            {
                result = result || !(Width > 0 && Height > 0 && Length > 0 && Weight > 0);
            }
            else
            {
                result = result || Package is null;
            }
            return !result;
        }
    }
}
