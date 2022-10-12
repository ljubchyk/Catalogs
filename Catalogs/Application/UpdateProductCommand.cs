using Catalogs.Domain;
using MediatR;

namespace Catalogs.Application
{
    public class UpdateProductCommand : IRequest<Product>
    {
        private readonly Guid id;
        private readonly string name;
        private readonly decimal price;
        private readonly decimal cost;
        private readonly string image;

        public UpdateProductCommand(Guid id, string name, decimal price, decimal cost, string image)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.cost = cost;
            this.image = image;
        }

        public string Name => name;
        public decimal Price => price;
        public decimal Cost => cost;
        public string Image => image;
        public Guid Id => id;
    }
}
