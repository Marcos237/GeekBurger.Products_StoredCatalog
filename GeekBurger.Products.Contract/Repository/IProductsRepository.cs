using GeekBurger.Products.Model;
using GeekBurger.StoreCatalog.Contract;
using System;
using System.Collections.Generic;

namespace GeekBurger.Products.Repository
{
    public interface IProductsRepository
    {
        Product GetProductById(Guid productId);
        List<Item> GetFullListOfItems();
        bool Add(Product product);
        bool Update(Product product);
        void Delete(Product product);
        void Save();
        IEnumerable<Product> GetProductsFromUser(User user);    
    }
}
