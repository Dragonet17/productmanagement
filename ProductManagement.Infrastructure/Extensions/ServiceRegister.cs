using System;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Infrastructure.Mappers;

namespace ProductManagement.Infrastructure.Extensions
{
    public static  class ServiceRegister
    {
        public static void RegisterServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProductMapper, ProductMapper>();
        }
    }
}
