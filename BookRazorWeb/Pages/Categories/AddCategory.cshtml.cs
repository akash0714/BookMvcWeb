using BookRazorWeb.Data;
using BookRazorWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookRazorWeb.Pages.Categories
{
    public class AddCategoryModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; } = new Category();
        readonly ApplicationDbContext _dbContext;
        public AddCategoryModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost() 
        {
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(Category);
                _dbContext.SaveChanges();
                TempData["Message"] = "Category Saved";
            }
            return Redirect("Categories");
        }
    }
}
