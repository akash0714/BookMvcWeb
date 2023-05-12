using BookRazorWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookRazorWeb.Data;
public class ApplicationDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>().HasData(new Category[] {
            new Category { Id = 1, Name = "Cartoons", DisplayOrder = 1 },
            new Category { Id = 2, Name = "Magazines", DisplayOrder = 2 },
            new Category { Id = 3, Name = "Novels", DisplayOrder = 3 },
        });
    }
}
