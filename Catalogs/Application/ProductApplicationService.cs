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

            var product = new Product();
            Map(product, domainProduct);
            return product;
        }

        public async Task<Product[]> GetList(int offset = 0, int limit = 10)
        {
            var domainProducts = await productRepository.GetList(offset, limit);
            
            return domainProducts.Select(dp =>
            {
                var product = new Product();
                Map(product, dp);
                return product;
            }).ToArray();
        }

        public async Task Update(Guid id, Product product)
        {
            var domainProduct = await productRepository.Get(id);
            if (domainProduct is null)
            {
                throw new InvalidOperationException($"Product with id: {id} not found.");
            }

            domainProduct.Rename(product.Name);
            domainProduct.ChangeCost(product.Cost);
            domainProduct.ChangePrice(product.Price);
            domainProduct.ChangeImage(product.Image);

            await unitOfWork.Commit();
        }

        public Task Add(Product product)
        {
            var domainProduct = new Domain.Product(
                Guid.NewGuid(),
                product.Name,
                product.Price,
                product.Cost,
                product.Image);
            productRepository.Add(domainProduct);

            Map(product, domainProduct);
            return unitOfWork.Commit();
        }

        public async Task Remove(Guid id)
        {
            var domainProduct = await productRepository.Get(id);
            if (domainProduct is null)
            {
                return;
            }

            productRepository.Remove(domainProduct);
            await unitOfWork.Commit();
        }

        public Task<string> UploadImage(string image)
        {
            throw new NotImplementedException();
        }

        private static void Map(Product destination, Domain.Product source)
        {
            destination.Id = source.Id;
            destination.Image = source.Image;
            destination.Cost = source.Cost;
            destination.Name = source.Name;
            destination.Price = source.Price;
        }
    }
}