using BookRazorWeb.Data;
using BookRazorWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookRazorWeb.Pages.Categories;

public class CategoriesModel : PageModel
{
    private ApplicationDbContext _dbContext;
    public List<Category> Categories { get; set; } = new List<Category>();
    public CategoriesModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void OnGet()
    {
        Categories = _dbContext.Categories.ToList();
    }
}
