using Book.Data;
using Book.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }
    }
}