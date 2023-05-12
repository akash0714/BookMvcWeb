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

    [HttpPost]
    public IActionResult AddCategory(Category category)
    {
        if (ModelState.IsValid)
        {
            if (category.Name?.ToLower() == "test")
            {
                ModelState.AddModelError("name", "Display name invalid.");
                return View(category);
            }
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            TempData["success"] = "Category added successfully.";
        }
        else 
        {
            return View(category); 
        }
        return RedirectToAction("Index", "Category");
    }

    [HttpGet]
    public IActionResult EditCategory(int? Id) 
    {
        if (Id == null || Id <= 0)
        {
            return NotFound(); 
        }
        var category = _dbContext.Categories.Find(Id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }

    [HttpPost]
    public IActionResult EditCategory(Category category)
    {
        if (ModelState.IsValid && category.Id > 0)
        {
            _dbContext.Categories.Update(category);
            _dbContext.SaveChanges();
            TempData["success"] = "Category updated successfully.";
        }
        else
        {
            return View(category);
        }
        return RedirectToAction("Index", "Category");
    }

    [HttpGet]
    public IActionResult DeleteCategory(int? Id)
    {
        if (Id == null || Id <= 0)
        {
            return NotFound();
        }
        var category = _dbContext.Categories.Find(Id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }

    [HttpPost, ActionName("DeleteCategory")]
    public IActionResult DeleteCategoryPOST(int? Id)
    {
        if (Id == null || Id <= 0)
        {
            return NotFound();
        }
        Category? category = _dbContext.Categories.Find(Id);
        if (category == null)
        {
            return NotFound();
        }
        else
        {
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            TempData["success"] = "Category deleted successfully.";
        }
        return RedirectToAction("Index");
    }
}
