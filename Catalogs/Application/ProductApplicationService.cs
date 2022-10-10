using Catalogs.Domain;
using Catalogs.Infrastructure;

namespace Catalogs.Application
{
    public class ProductApplicationService
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductApplicationService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Product> Get(Guid id)
        {
            var domainProduct = await productRepository.Get(id);
            if (domainProduct is null)
            {
                return null;
            }

            return new Product
            {
                Cost = domainProduct.Cost,
                Id = domainProduct.Id,
                Image = domainProduct.Image,
                Name = domainProduct.Name,
                Price = domainProduct.Price
            };
        }
    }
}