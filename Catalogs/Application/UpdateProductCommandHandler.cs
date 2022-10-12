using Catalogs.Domain;
using Catalogs.Infrastructure;
using MediatR;

namespace Catalogs.Application
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;

        public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var domainProduct = await productRepository.Get(request.Id);
            if (domainProduct is null)
            {
                throw new InvalidOperationException($"Product with id: {request.Id} not found.");
            }

            domainProduct.Rename(request.Name);
            domainProduct.ChangeCost(request.Cost);
            domainProduct.ChangePrice(request.Price);
            domainProduct.ChangeImage(request.Image);

            await unitOfWork.Commit();
            return domainProduct;
        }
    }
}
