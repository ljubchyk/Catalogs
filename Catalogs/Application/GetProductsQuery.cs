using Catalogs.Domain;
using MediatR;

namespace Catalogs.Application
{
    public class GetProductsQuery : IRequest<Product[]>
    {
        private readonly int offset;
        private readonly int limit;

        public GetProductsQuery(int offset, int limit)
        {
            this.offset = offset;
            this.limit = limit;
        }

        public int Offset => offset;
        public int Limit => limit;
    }
}
