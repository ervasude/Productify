using Microsoft.AspNetCore.Mvc;
using Productify.Persistence.Context;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Productify.MVC.Controllers
{
    public class ProductController : Controller
    {
        //List<Product> _products = new()
        //{

        //   new Product("Laptop"),
        //   new Product("Smartphone"),
        //   new Product("Desk Chair"),
        //   new Product("Coffee Maker"),
        //   new Product("Headphones"),

        //};

        ProductifyDbContext _context;

        public ProductController()
        {
            _context = new();
        }

        public IActionResult All => View(_context.Products.ToList());

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(string productName)
        {
            _context.Products.Add(new(productName));
            _context.SaveChanges();
            return View();
        }
    }
}

