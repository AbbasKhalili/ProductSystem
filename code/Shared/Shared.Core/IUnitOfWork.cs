namespace Shared.Core
{
    public interface IUnitOfWork
    {
        Task Begin();
        Task Commit();
        Task Rollback();

        Task SaveChangesAsync();
    }
}
