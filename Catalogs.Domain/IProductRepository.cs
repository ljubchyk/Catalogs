using System;
using System.Threading.Tasks;

namespace Catalogs.Domain
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Remove(Product product);
        Task<Product> Get(Guid id);
    }
}
