
using MobileClientApp.Models.Values;

namespace MobileClientApp.Interfaces
{
    public interface INotification
    {
        public ValueTask<LocationCommand> DequeueAsync(CancellationToken cancellationToken);
    }
}