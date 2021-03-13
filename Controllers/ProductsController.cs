using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapi_productos.Models.Products;

namespace webapi_productos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _loggger;
        public ProductsController(ILogger<ProductsController> loggger)
        {
            _loggger = loggger;
        }

        private static string[] _names = new[] { "Smart TV", "Smart Watch", "Cellphone", "iPad Pro", "iPhone X", "Laptop i5 16GB RAM", "Laptop Ryzen 5000 16GB RAM", "Smart Hat" };

        private IEnumerable<Product> GetEnumerable(){

            var result = Enumerable.Range(0, 15).Select(index => {
                var rand = new Random();
                return new Product{
                    Name = _names[rand.Next(0, 7)],
                    CreationDate = DateTime.Now.AddDays(-rand.Next(31)),
                    Description = "..."
                };
            });

            return result;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            _loggger.LogInformation("Obteniendo productos...");
            var response = GetEnumerable();
            _loggger.LogInformation("Productos obtenidos.");

            return response;
        }
    }
}