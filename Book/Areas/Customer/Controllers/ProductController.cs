using Book.Data;
using Book.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Book.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //var Products = _context.Products.ToList();

            return View();
        }

        public IActionResult GetAll()
        {
            var products = _context.Products
                .Include(p => p.Category)
                .ToList();

            return Json(new { data = products });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }
    }
}