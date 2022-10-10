using Catalogs.Domain;
using Microsoft.EntityFrameworkCore;

namespace Catalogs.Infrastructure
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }
    }
}