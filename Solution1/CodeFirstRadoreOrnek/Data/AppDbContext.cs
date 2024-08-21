using CodeFirstRadoreOrnek.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstRadoreOrnek.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // Türediğimiz class ın ctor una parametre gönderiyoruz
        {
        }

        public DbSet<Book> Book { get; set; }
    }
}