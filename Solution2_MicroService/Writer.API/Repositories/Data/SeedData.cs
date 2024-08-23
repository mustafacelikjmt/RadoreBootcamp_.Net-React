using Microsoft.EntityFrameworkCore;
using Writer.API.Models;

namespace Writer.API.Repositories.Data
{
    public class SeedData
    {
        public static async Task SeedDataWriter(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
                if (!await context.Writer.AnyAsync())
                {
                    await context.Writer.AddRangeAsync(
                        new WriterModel { Name = "Mustafa" },
                        new WriterModel { Name = "Mehmet" },
                        new WriterModel { Name = "Fatih" }
                        );
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}