
namespace MobileClientApp.Interfaces
{
    public interface IStorage<TEntity>
    {
        public TEntity GetData();
    }
}
