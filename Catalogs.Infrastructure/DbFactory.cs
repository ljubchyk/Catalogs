using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Catalogs.Infrastructure
{
    public class DbFactory : IDesignTimeDbContextFactory<Db>
    {
        public Db CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Db>();
            optionsBuilder.UseSqlServer(
                "Server=.;Initial Catalog=Catalog;Integrated Security=true");

            return new Db(optionsBuilder.Options);
        }
    }
}