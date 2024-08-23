using Article.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Article.API.Repositories.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ArticleModel> Article { get; set; }
    }
}