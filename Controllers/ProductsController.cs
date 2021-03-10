using System;
using System.Collections.Generic;
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

        [HttpGet]
        public IEnumerable<Product> GetEnumerable()
        {
            _loggger.LogInformation("Obteniendo productos...");
            var response = new Product[]{
                new Product{ Name = "Smart TV", Description = "...", CreationDate = DateTime.Now },
                new Product{ Name = "CellPhone", Description = "...", CreationDate = DateTime.Now },
            };

            _loggger.LogInformation("Productos obtenidos.");
            return response;
        }
    }
}