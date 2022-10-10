using System;

namespace Catalogs.Domain
{
    public class Product : Entity
    {
        private readonly Guid id;
        private readonly string name;
        private readonly decimal price;
        private readonly decimal cost;
        private readonly string image;

        private Product()
        {

        }

        public Product(Guid id, string name, decimal price, decimal cost, string image)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(image))
            {
                throw new ArgumentException($"'{nameof(image)}' cannot be null or whitespace.", nameof(image));
            }

            if (price <= 0)
            {
                throw new ArgumentException($"'{nameof(price)}' must be > 0.", nameof(price));
            }

            if (cost <= 0)
            {
                throw new ArgumentException($"'{nameof(cost)}' must be > 0.", nameof(cost));
            }

            this.id = id;
            this.name = name;
            this.price = price;
            this.cost = cost;
            this.image = image;

            AddDomainEvent(new ProductCreated(id, name));
        }

        public string Name => name;
        public decimal Price => price;
        public decimal Cost => cost;
        public string Image => image;
        public Guid Id => id;
    }
}
