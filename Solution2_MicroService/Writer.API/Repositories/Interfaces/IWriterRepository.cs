namespace Writer.API.Models;

public interface IWriterRepository
{
    IQueryable<WriterModel> GetAll();

    Task<WriterModel?> GetByIdAsync(int id);

    Task AddAsync(WriterModel entity);

    Task UpdateAsync(WriterModel entity);

    Task DeleteAsync(WriterModel entity);
}