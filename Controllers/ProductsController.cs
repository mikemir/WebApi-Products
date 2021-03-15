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

        private static string[] _names = new[] {
                                                "Smart TV",
                                                "Smart Watch",
                                                "Cellphone",
                                                "iPad Pro",
                                                "iPhone X",
                                                "Laptop i5 16GB RAM",
                                                "Laptop Ryzen 5000 16GB RAM",
                                                "Smart Hat",
                                                "Monitor HP 24f",
                                                "Bluetooth Speaker"
                                            };

        private static string[] _brands = new[]{
                                                "Samsung",
                                                "Xiaomi",
                                                "Huawei",
                                                "Apple",
                                                "Sony"
                                            };

        private IEnumerable<Product> GetEnumerable(){

            var result = Enumerable.Range(0, 15).Select(index => {
                var rand = new Random();
                return new Product{
                    Name = _names[rand.Next(_names.Length -1)],
                    CreationDate = DateTime.Now.AddDays(-rand.Next(31)),
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.",
                    Brand = _brands[rand.Next(_brands.Length -1)]
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