namespace Writer.API.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync();

        void Commit();
    }
}