using Catalogs.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Catalogs.Infrastructure
{
    public static class Ex
    {
        public static void AddInfrastructure(this IServiceCollection serviceCollection, string dbConnectionString)
        {
            serviceCollection.AddDbContext<Db>(options
                => options.UseSqlServer(dbConnectionString));
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}