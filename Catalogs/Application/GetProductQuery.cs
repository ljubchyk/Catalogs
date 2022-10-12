using Catalogs.Domain;
using MediatR;

namespace Catalogs.Application
{
    public class GetProductQuery : IRequest<Product>
    {
        private readonly Guid id;

        public GetProductQuery(Guid id)
        {
            this.id = id;
        }

        public Guid Id => id;
    }
}
