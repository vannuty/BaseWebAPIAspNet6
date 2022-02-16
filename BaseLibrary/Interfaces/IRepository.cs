namespace BaseLibrary.Interfaces
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
    }
}
