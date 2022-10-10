using System;

namespace Catalogs.Domain
{
    public class ProductCreated : DomainEvent
    {
        public ProductCreated(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }
    }
}
