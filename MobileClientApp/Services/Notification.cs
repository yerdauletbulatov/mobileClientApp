using Microsoft.AspNetCore.SignalR.Client;
using MobileClientApp.Helper;
using MobileClientApp.Interfaces;
using MobileClientApp.Models.Values;
using MobileClientApp.ViewModels;
using System.ComponentModel;
using System.Threading.Channels;

namespace MobileClientApp.Services
{
    public class Notification : INotification
    {
        public HubConnection _connection;
        private readonly Channel<LocationCommand> _queue;

        public Notification()
        {
            _queue = Channel.CreateUnbounded<LocationCommand>();
            // создаем подключение к хабу
            _connection = new HubConnectionBuilder().WithUrl($"{API.Hub}", options =>
            {
                var token = Preferences.Get(nameof(JWT.AccessToken), string.Empty);
                options.AccessTokenProvider = async () => await Task.FromResult(token);
            }).Build();

            // регистрируем функцию SendClientInfoToDriver для получения данных
            _connection.On<string>("SendToClient", async (message) =>
            {
                await SendLocalMessage(message);
            });    
            _connection.On<LocationCommand>("ReceiveDriverLocation", async (locationCommand) =>
            {
                await _queue.Writer.WriteAsync(locationCommand);
            });

            // череp 3 секунду переподключаемся   
            _connection.Closed += async (error) =>
            {
                await Task.Delay(3000);
                await _connection.StartAsync();
            };
            //подключение хабу
            _connection.StartAsync();
        }

        public async ValueTask<LocationCommand> DequeueAsync(CancellationToken cancellationToken) =>
            await _queue.Reader.ReadAsync(cancellationToken);
        private async Task SendLocalMessage(string message)
        {
            await Shell.Current.DisplayAlert("Уведомление", $"{message}", "Ок");
        }
    }
}
