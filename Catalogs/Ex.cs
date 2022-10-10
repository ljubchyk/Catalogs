using MassTransit;
using Catalogs.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Catalogs
{
    public static class Ex
    {
        public static void AddApplication(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddMassTransit(configurator =>
            {
                //configurator.AddConsumer<T>();
                configurator.UsingInMemory((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });
            });
            serviceCollection.AddInfrastructure(
                configuration.GetConnectionString("db"));
        }
    }
}