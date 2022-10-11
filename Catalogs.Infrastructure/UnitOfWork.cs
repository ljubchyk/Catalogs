using Catalogs.Domain;
using MassTransit;
using MassTransit.Mediator;

namespace Catalogs.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Db db;
        private readonly IBus bus;

        public UnitOfWork(Db db, IBus bus)
        {
            this.db = db;
            this.bus = bus;
        }

        public async Task Commit()
        {
            await db.SaveChangesAsync();

            //use outbox
            foreach (var entry in db.ChangeTracker.Entries())
            {
                foreach (var domainEvent in ((Entity)entry.Entity).DomainEvents)
                {
                    bus.Publish(domainEvent);
                }
            }
        }
    }
}