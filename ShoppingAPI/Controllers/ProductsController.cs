using ShoppingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        Product[] products = new Product[]
        {
            new Product {Id = 1, Name = "Amazon Kindle Paperwhite", Category = "E-Readers", Price = 100 },
            new Product {Id = 2, Name = "iPad Pro 11", Category = "Tablets", Price = 900 },
            new Product {Id = 1, Name = "Kobo Aura H2O ", Category = "E-Reader", Price = 175 },
            new Product {Id = 1, Name = "Samsung Galaxy Tab S4", Category = "Tablets", Price = 700 },
        };

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return products;
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetProductById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}