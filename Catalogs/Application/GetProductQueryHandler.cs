using Catalogs.Domain;
using MediatR;

namespace Catalogs.Application
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
    {
        private readonly IProductRepository productRepository;

        public GetProductQueryHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return productRepository.Get(request.Id);
        }
    }
}
