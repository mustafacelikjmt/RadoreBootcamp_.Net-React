using Microsoft.EntityFrameworkCore;
using Writer.API.Models;
using Writer.API.Repositories.Data;
using Writer.API.Repositories.UnitOfWork;

namespace Writer.API.Repositories
{
    public class WriterRepository : IWriterRepository // : List<WriterModel>,
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public WriterRepository(AppDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public IQueryable<WriterModel> GetAll()
        {
            return _context.Writer;
        }

        public async Task<WriterModel?> GetByIdAsync(int id)
        {
            return await _context.Writer.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(WriterModel entity)
        {
            await _context.Writer.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(WriterModel entity)
        {
            var editWriter = await _context.Writer.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (editWriter != null)
            {
                editWriter.Name = entity.Name;
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task DeleteAsync(WriterModel entity)
        {
            _context.Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        /*//old code
        private static List<WriterModel> writers = PopulateWriters();

        private static List<WriterModel> PopulateWriters()
        {
            return new List<WriterModel>() {
                new WriterModel()
                {
                    Id=1,
                    Name="Ibrahim Gokyar"
                },new WriterModel()
                {
                    Id=2,
                    Name="Hakan Yilmaz"
                },new WriterModel()
                {
                    Id=3,
                    Name="Metin Yildiz"
                }};
        }

        public WriterModel? Get(int id)
        {
            return writers.FirstOrDefault(x => x.Id == id);
        }

        public List<WriterModel> GetAll()
        {
            return writers;
        }

        public WriterModel Insert(WriterModel writer)
        {
            var maxId = writers.Max(x => x.Id);
            writer.Id = ++maxId;
            writers.Add(writer);
            return writer;
        }*/
    }
}