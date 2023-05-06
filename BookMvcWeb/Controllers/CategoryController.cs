using BookMvcWeb.Data;
using BookMvcWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMvcWeb.Controllers;

public class CategoryController : Controller
{
    private ApplicationDbContext _dbContext;
    public CategoryController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        List<Category> categories = _dbContext.Categories.OrderBy(cat => cat.DisplayOrder).ToList();
        return View(categories.ToList());
    }

    [HttpGet]
    public IActionResult AddCategory()
    {
        return View();
    }
}
