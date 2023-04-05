using GeekBurger.Products.Model;
using GeekBurger.Products.Service;
using GeekBurger.StoreCatalog.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekBurger.Products.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private ProductsDbContext _dbContext;
        private IProductChangedService _productChangedService;

        public ProductsRepository(ProductsDbContext dbContext, IProductChangedService productChangedService)
        {
            _dbContext = dbContext;
            _productChangedService = productChangedService;
        }

        public Product GetProductById(Guid productId)
        {
            return _dbContext.Products?
                .Include(product => product.Items)
                .FirstOrDefault(product => product.ProductId == productId);
        }

        public List<Item> GetFullListOfItems()
        {
            return _dbContext.Items.ToList();
        }

        public bool Add(Product product)
        {
            product.ProductId = Guid.NewGuid();
            _dbContext.Products.Add(product);
            return true;
        }

        public bool Update(Product product)
        {
            return true;
        }


        public void Delete(Product product)
        {
            _dbContext.Products.Remove(product);
        }

        public void Save()
        {
            _productChangedService
                .AddToMessageList(_dbContext.ChangeTracker.Entries<Product>());

            _dbContext.SaveChanges();

            _productChangedService.SendMessagesAsync();
        }
        public IEnumerable<Product> GetProductsFromUser(User user)
        {
            var list = new List<Product>();
            var prod = new Product()
            {
                ProductId = Guid.NewGuid(),
                user = user,
                Items = new List<Item>()
                {
                    new Item() {
                    ItemId = Guid.NewGuid().ToString(),
                    ingredients = new List<string>()
                    }
                }          
            };
            return new List<Product>().Where(c => c.user == user);
        }
    }
}
