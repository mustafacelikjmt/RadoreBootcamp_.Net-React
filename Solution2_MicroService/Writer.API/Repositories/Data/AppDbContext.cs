using Microsoft.EntityFrameworkCore;
using Writer.API.Models;

namespace Writer.API.Repositories.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<WriterModel> Writer { get; set; }
    }
}