using Microsoft.AspNetCore.Mvc;
using Project_LINTNER.Models;

namespace Project_LINTNER.Controllers
{
    public class Productcontroller : Controller
    {
        private readonly ApplicationDbContext _context;
        public Productcontroller(ApplicationDbContext context)
        {
            _context = context;
        }





        public IActionResult Index()
        {
            List<Product> products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Edit(int id)
        {
            Product product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return View(product);

        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(product);

        }






        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
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
