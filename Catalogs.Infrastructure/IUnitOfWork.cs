namespace Catalogs.Infrastructure
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}