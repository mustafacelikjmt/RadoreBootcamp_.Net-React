using Article.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Article.API.Repositories.Data
{
    public class SeedData
    {
        public static async Task SeedDataArticle(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
                if (!await context.Article.AnyAsync())
                {
                    await context.Article.AddRangeAsync(
                        new ArticleModel { Title = "Identity Temelleri", LastUpdate = DateTime.Now, WriterId = 1 },
                        new ArticleModel { Title = "Mikro Servis Dünyası", LastUpdate = DateTime.Now, WriterId = 2 },
                        new ArticleModel { Title = "React Vs Blazor", LastUpdate = DateTime.Now, WriterId = 3 }
                        );
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}