using Catalogs.Domain;
using Catalogs.Infrastructure;
using MediatR;

namespace Catalogs.Application
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(
                Guid.NewGuid(),
                request.Name,
                request.Price,
                request.Cost,
                request.Image);
            productRepository.Add(product);

            await unitOfWork.Commit();
            return product;
        }
    }
}
