using Book.Data;
using Book.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book.Controllers
{
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
            return View("Index" , categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public IActionResult CreatePOST(Category category)
        {
            if(ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                TempData["success"] = "Category Insert successfully";

                return RedirectToAction("Index");
            }
            return View();
           
        }

        public IActionResult Update(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var category = _context.Categories.Find(id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Update")]
        public IActionResult UpdatePOST(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                TempData["success"] = "Category Update successfully";

                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            TempData["success"] = "Category deleted successfully";

            return RedirectToAction(nameof(Index));
        }


    }
}
