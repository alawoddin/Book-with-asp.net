using Book.Data;
using Book.Models;
using Microsoft.AspNetCore.Mvc;

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
            var Products = _context.Products.ToList();

            return View(Products);
        }

        public IActionResult GetAll()
        {
            var Products = _context.Products.ToList();

            return Json(new {data= Products });
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