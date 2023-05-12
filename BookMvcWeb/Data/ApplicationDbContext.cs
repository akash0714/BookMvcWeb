using BookMvcWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookMvcWeb.Data;
public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
        
    }
    public DbSet<Category> Categories { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(new Category[] 
        { 
            new Category() { Id = 1, Name="Cartoon", DisplayOrder = 0 },
            new Category() { Id = 2, Name="Novel", DisplayOrder = 1 },
            new Category() { Id = 3, Name="SciFi", DisplayOrder = 2 },
        });
    }
}
