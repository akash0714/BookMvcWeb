using BookMvc.DataAccess.Repositories.Interfaces;
using BookMvc.Models;
using BookMvc.Models.ViewModels;
using BookMVC.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookMvcWeb.Areas.Administrator.Controllers
{
    [Area(ConstantUtility.AdminArea)]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var products = _productRepository.GetAll().ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            IEnumerable<SelectListItem> categoryList = _categoryRepository.GetAll().Select(cat => new SelectListItem(cat.Name, cat.Id.ToString()));
            ProductViewModel viewModel = new ProductViewModel()
            {
                CategoryList = categoryList
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddProduct(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Add(productViewModel.Product);
                _productRepository.SaveChanges();
                TempData["success"] = "Product added successfully.";
            }
            else
            {
                productViewModel.CategoryList = _categoryRepository.GetAll().Select(cat => new SelectListItem(cat.Name, cat.Id.ToString()));
                return View(productViewModel);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditProduct(int? id)
        {
            if ( id == null || id < 1)
            {
                return NotFound();
            }
            var dbProduct = _productRepository.Get(product => product.Id == id);
            if (dbProduct == null)
            {
                return NotFound();
            }
            IEnumerable<SelectListItem> categoryList = _categoryRepository.GetAll().Select(cat => new SelectListItem(cat.Name, cat.Id.ToString()));
            ViewBag.CategoryList = categoryList;
            return View(dbProduct);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Update(product);
                _productRepository.SaveChanges();
                TempData["success"] = "Product updated successfully.";
            }
            else
            {
                return View(product);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteProduct(int? id)
        {
            if (id != null && id > 0)
            {
                var dbProduct = _productRepository.Get(product => product.Id == id);
                if (dbProduct == null)
                {
                    return NotFound();
                }
                IEnumerable<SelectListItem> categoryList = _categoryRepository.GetAll().Select(cat => new SelectListItem(cat.Name, cat.Id.ToString()));
                ViewBag.CategoryList = categoryList;
                return View(dbProduct);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteProduct(Product product)
        {
            if (product.Id > 0)
            {
                _productRepository.Remove(product);
                _productRepository.SaveChanges();
                TempData["success"] = "Product deleted successfully.";
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
