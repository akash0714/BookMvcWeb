using BookMvcWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookMvcWeb.Data;
public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
        
    }
    public DbSet<Category> Categories { get; set; }
}
