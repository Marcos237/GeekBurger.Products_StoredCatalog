using GeekBurger.StoreCatalog.Contract;
using System;

namespace GeekBurger.Products.Contract
{
    public class ProductToGet
    {
        public User User { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
    }
}