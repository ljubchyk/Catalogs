using Catalogs.Domain;
using Microsoft.EntityFrameworkCore;

namespace Catalogs.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly Db db;

        public ProductRepository(Db db)
        {
            this.db = db;
        }

        public void Add(Product product)
        {
            db.Add(product);
        }

        public Task<Product> Get(Guid id)
        {
            return db.FindAsync<Product>(id).AsTask();
        }

        public Task<Product[]> GetList(int offset = 0, int limit = 10)
        {
            return db.Products.Skip(offset).Take(limit).ToArrayAsync();
        }

        public void Remove(Product product)
        {
            db.Remove(product);
        }
    }
}