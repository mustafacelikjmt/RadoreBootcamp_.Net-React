using Microsoft.EntityFrameworkCore;

namespace JwtRadoreOrnek.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=JwtSampleRadore.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = 1,
                FirstName = "test",
                UserName = "testUser",
                Password = "testPassword"
            });
        }
    }
}