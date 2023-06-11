using BookMvc.DataAccess.Repositories.Interfaces;
using BookMvc.Models;
using BookMVC.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookMvc.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public IActionResult Index()
    {
        List<Category> categories = _categoryRepository.GetAll().OrderBy(cat => cat.DisplayOrder).ToList();
        return View(categories);
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
            _categoryRepository.Add(category);
            _categoryRepository.SaveChanges();
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
        var category = _categoryRepository.Get(category => category.Id == Id);
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
            _categoryRepository.Update(category);
            _categoryRepository.SaveChanges();
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
        var category = _categoryRepository.Get(category => category.Id == Id);
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
        Category? category = _categoryRepository.Get(category => category.Id == Id);
        if (category == null)
        {
            return NotFound();
        }
        else
        {
            _categoryRepository.Remove(category);
            _categoryRepository.SaveChanges();
            TempData["success"] = "Category deleted successfully.";
        }
        return RedirectToAction("Index");
    }
}
