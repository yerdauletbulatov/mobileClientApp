using MobileClientApp.Models;
using MobileClientApp.Models.Enitities;

namespace MobileClientApp;

public partial class App : Application
{
	public static List<Package> PackageList = new List<Package>();  
	public App()
	{
		InitializeComponent();
		MainPage = new AppShell();
        InitializePackageList();
    }

    private void InitializePackageList()
	{
		PackageList.Add(new Package() { Name = "Пакет(40x30x20)см^3", Height = 0.4, Width = 0.3, Length = 0.2 });
		PackageList.Add(new Package() { Name = "Коробка(60x40x30)см^3", Height = 0.6, Width = 0.4, Length = 0.3 });
		PackageList.Add(new Package() { Name = "Тележка или палет(100x50x50)см^3", Height = 1, Width = 0.5, Length = 0.5 });
    }

}
