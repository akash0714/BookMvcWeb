using BookMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace BookMVC.DataAccess.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(new Category[]
        {
            new Category() { Id = 1, Name="Cartoon", DisplayOrder = 0 },
            new Category() { Id = 2, Name="Novel", DisplayOrder = 1 },
            new Category() { Id = 3, Name="SciFi", DisplayOrder = 2 },
        });
        modelBuilder.Entity<Product>().HasData(new Product[]
        {
            new Product() { Id = 1, Title = "Tom & Jerry", Author = "Golwyn Mayor", UnitPrice = 100, Price50 = 85, Price100 = 75, CategoryId = 1 },
            new Product() { Id = 2, Title = "Passengers", Author = "20th Century Fox", UnitPrice = 125, Price50 = 110, Price100 = 95, CategoryId = 3 },
            new Product() { Id = 3, Title = "Game Of Thrones", Author = "Unknown", UnitPrice = 150, Price50 = 110, Price100 = 98, CategoryId = 2 }
        });
    }
}
