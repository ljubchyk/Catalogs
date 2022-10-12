using Catalogs.Domain;
using Catalogs.Infrastructure;
using MediatR;

namespace Catalogs.Application
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand>
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;

        public RemoveProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var domainProduct = await productRepository.Get(request.Id);
            if (domainProduct is null)
            {
                return Unit.Value;
            }

            productRepository.Remove(domainProduct);
            await unitOfWork.Commit();
            return Unit.Value;
        }
    }
}
