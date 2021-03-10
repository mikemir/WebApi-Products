using System;

namespace webapi_productos.Models.Products
{
    public class Product
    {
        public Product()
        {
            ProductId = Guid.NewGuid().ToString();
        }

        public string ProductId { private get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public override int GetHashCode()
        {
            return ProductId.GetHashCode();
        }

        public override string ToString()
        {
            return $"Id: {ProductId}, Name: {Name}";
        }
    }
}