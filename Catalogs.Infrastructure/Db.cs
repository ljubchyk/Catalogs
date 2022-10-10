using Catalogs.Domain;
using Microsoft.EntityFrameworkCore;

namespace Catalogs.Infrastructure
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().
                Property(p => p.Id);
            modelBuilder.Entity<Product>().
                Property(p => p.Name);
            modelBuilder.Entity<Product>().
                Property(p => p.Price);
            modelBuilder.Entity<Product>().
                Property(p => p.Cost);
            modelBuilder.Entity<Product>().
                Property(p => p.Image);
            modelBuilder.Entity<Product>().
                Ignore(p => p.DomainEvents);
        }
    }
}