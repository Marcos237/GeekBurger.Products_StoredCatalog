using GeekBurger.StoreCatalog.Contract;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace GeekBurger.Products.Service
{
    public interface IProductChangedService : IHostedService
    {
        void SendMessagesAsync();
        void AddToMessageList(IEnumerable<EntityEntry<Product>> changes);
    }
}