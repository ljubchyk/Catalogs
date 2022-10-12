using Catalogs.Domain;
using MediatR;
using System.Collections.Generic;

namespace Catalogs.Application
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, Product[]>
    {
        private readonly IProductRepository productRepository;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Task<Product[]> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return productRepository.GetList(
                request.Offset,
                request.Limit);
        }
    }
}
