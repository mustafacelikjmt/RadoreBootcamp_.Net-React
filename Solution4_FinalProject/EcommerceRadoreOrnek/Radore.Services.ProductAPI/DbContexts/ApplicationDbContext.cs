using Microsoft.EntityFrameworkCore;
using Radore.Services.ProductAPI.Models;

namespace Radore.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Samosa",
                Price = 15,
                Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                ImageUrl = "samosa.jpg",
                CategoryName = "Appetizer"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Paneer Tikka",
                Price = 13.99,
                Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                ImageUrl = "panertikka.jpg",
                CategoryName = "Appetizer"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Sweet Pie",
                Price = 10.99,
                Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                ImageUrl = "sweetpie.jpg",
                CategoryName = "Dessert"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Pav Bhaji",
                Price = 15,
                Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                ImageUrl = "pavbhaji.jpg",
                CategoryName = "Entree"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 5,
                Name = "Green Dress For Woman",
                Price = 38,
                Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                ImageUrl = "product1.png",
                CategoryName = "fashion"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 6,
                Name = "T-Shirt For Men",
                Price = 72,
                Description = "Vivamus suscipit tortor eget felis porttitor volutpat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin eget tortor risus. Nulla porttitor accumsan tincidunt. Pellentesque in ipsum id orci porta dapibus.",
                ImageUrl = "product2.png",
                CategoryName = "fashion"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 7,
                Name = "V - Neck Dress",
                Price = 34,
                Description = "Praesent sapien massa, convallis a pellentesque nec, egestas non nisi. Vestibulum ante ipsum primis faucibus orci luctus et ultrices posuere cubilia Curae;",
                ImageUrl = "product3.png",
                CategoryName = "fashion"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 8,
                Name = "Maxi Dress",
                Price = 43,
                Description = "Donec velit neque, auctor sit amet aliquam vel, ullamcorper sit amet ligula. Vestibulum ac diam sit amet quam vehicula elementum sed sit amet dui. Quisque velit nisi, pretium ut lacinia in, elementum id enim.",
                ImageUrl = "product4.png",
                CategoryName = "fashion"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 9,
                Name = "Fit-Flare Dress",
                Price = 52,
                Description = "Donec sollicitudin molestie malesuada. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus suscipit tortor eget felis porttitor volutpat. Nulla quis lorem ut libero malesuada feugiat.",
                ImageUrl = "product5.png",
                CategoryName = "fashion"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 10,
                Name = "Midi Dress",
                Price = 14,
                Description = "Nulla quis lorem ut libero malesuada feugiat. Quisque velit nisi, pretium ut lacinia in, elementum id enim. Curabitur non nulla sit amet nisl tempus convallis quis ac lectus. Donec sollicitudin molestie malesuada",
                ImageUrl = "product6.png",
                CategoryName = "fashion"
            });
        }
    }
}