using BookRazorWeb.Data;
using BookRazorWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookRazorWeb.Pages.Categories
{
    public class EditCategoryModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; } = new Category();
        private readonly ApplicationDbContext _dbContext;
        public EditCategoryModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnGet(int? Id)
        {
            if (Id != null)
            {
                Category? dbCategory = _dbContext.Categories.Find(Id);
                if (dbCategory != null)
                {
                    Category = dbCategory;
                }
            }
        }

        public IActionResult OnPost()
        {
            if (Category != null && ModelState.IsValid)
            {
                _dbContext.Categories.Update(Category);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Categories");
        }

    }
}
