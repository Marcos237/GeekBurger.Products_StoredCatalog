using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GeekBurger.StoreCatalog.Contract
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public User user { get; set; }

        public static IEnumerable<Product> GetProducts(string json)
        {
            return JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
        }
    }
}
