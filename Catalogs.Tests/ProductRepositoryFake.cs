using Catalogs.Domain;

namespace Catalogs.Tests
{
    public class ProductRepositoryFake : IProductRepository
    {
        private readonly Dictionary<Guid, Domain.Product> products
            = new();

        public void Add(Domain.Product product)
        {
            products.Add(product.Id, product);
        }

        public Task<Domain.Product> Get(Guid id)
        {
            return Task.FromResult(products[id]);
        }

        public Task<Domain.Product[]> GetList(int offset = 0, int limit = 10)
        {
            return Task.FromResult(products.Values.Skip(offset).Take(limit).ToArray());
        }

        public void Remove(Domain.Product product)
        {
            products.Remove(product.Id);
        }
    }
}