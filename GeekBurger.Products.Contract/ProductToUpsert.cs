using System;
using System.Collections.Generic;

namespace GeekBurger.Products.Contract
{
    public class ProductToUpsert
    {
        public string userName { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public decimal Price { get; set; }
    }
}