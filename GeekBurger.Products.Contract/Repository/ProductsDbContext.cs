using GeekBurger.Products.Model;
using GeekBurger.StoreCatalog.Contract;
using Microsoft.EntityFrameworkCore;

namespace GeekBurger.Products.Repository
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
           : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ProductChangedEvent> ProductChangedEvents { get; set; }
    }
}
