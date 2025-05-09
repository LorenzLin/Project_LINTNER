using Microsoft.AspNetCore.Mvc;
using Project_LINTNER.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

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



        public class UploadModel : PageModel
        {
            [BindProperty]
            public IFormFile ImageFile { get; set; }

            public string ImagePath { get; private set; }
            public bool UploadSuccess { get; private set; } = false;
            public string ErrorMessage { get; private set; }

            public async Task<IActionResult> OnPostAsync()
            {
                if (ImageFile == null || ImageFile.Length == 0)
                {
                    ErrorMessage = "Please select an image file.";
                    return Page();
                }

                // Check file type
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var extension = Path.GetExtension(ImageFile.FileName).ToLower();

                if (!allowedExtensions.Contains(extension))
                {
                    ErrorMessage = "Only image files (.jpg, .jpeg, .png, .gif) are allowed.";
                    return Page();
                }

                // Save the file
                var uploadsFolder = Path.Combine("wwwroot", "uploads");
                Directory.CreateDirectory(uploadsFolder);

                var filePath = Path.Combine(uploadsFolder, Path.GetFileName(ImageFile.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                ImagePath = "/uploads/" + Path.GetFileName(ImageFile.FileName);
                UploadSuccess = true;
                return Page();





            }
        }











    }
}
