using Microsoft.AspNetCore.Mvc;
using Project_LINTNER.Models;

namespace Project_LINTNER.Controllers
{
    public class Productcontroller : Controller
    {

        public IActionResult Index()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "Laptop", price = 1000 });
            products.Add(new Product { Id = 2, Name = "Iphone", price = 1400 });
            products.Add(new Product { Id = 3, Name = "PC (not working)", price = 2000 });
            products.Add(new Product { Id = 4, Name = "Raspberry", price = 90 });
            return View(products);
        }
    }
}
