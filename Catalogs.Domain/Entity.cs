using System.Collections.Generic;

namespace Catalogs.Domain
{
    public class Entity
    {
        private readonly List<DomainEvent> domainEvents;

        protected Entity()
        {
            domainEvents = new List<DomainEvent>();
        }

        public IReadOnlyList<DomainEvent> DomainEvents =>
            domainEvents;

        public void AddDomainEvent(DomainEvent domainEvent)
        {
            domainEvents.Add(domainEvent);
        }
    }
}
