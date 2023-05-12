using BookRazorWeb.Data;
using BookRazorWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookRazorWeb.Pages.Categories
{
    public class DeleteCategoryModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; } = new Category();
        private readonly ApplicationDbContext _dbContext;
        public DeleteCategoryModel(ApplicationDbContext dbContext)
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
            Category? dbCategory = _dbContext.Categories.Find(Category.Id);
            if (dbCategory != null)
            {
                _dbContext.Categories.Remove(dbCategory);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Categories");
        }
    }
}
