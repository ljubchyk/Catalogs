using MassTransit;
using Catalogs.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;

namespace Catalogs
{
    public static class Ex
    {
        public static void AddApplication(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
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
            //serviceCollection.AddScoped<Application.ProductApplicationService>();
        }
    }
}