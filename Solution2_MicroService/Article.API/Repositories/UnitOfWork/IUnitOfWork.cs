namespace Article.API.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync();

        void Commit();
    }
}