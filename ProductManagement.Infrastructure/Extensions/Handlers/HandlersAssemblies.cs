using ProductManagement.Infrastructure.Handlers;
using ProductManagement.Infrastructure.Handlers.Product;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;

namespace ProductManagement.Infrastructure.Extensions.Handlers
{
    public static class HandlersAssemblies
    {
        private static readonly List<Assembly> Assemblies = new List<Assembly>();

        private static readonly ImmutableList<Assembly> ProductAssemblies = new List<Assembly>
        {
            typeof(CreateProductHandler).Assembly,
            typeof(DeleteProductHandler).Assembly,
            typeof(UpdateProductHandler).Assembly,
            typeof(GetAllProductsHandler).Assembly,
            typeof(GetProductByIdHandler).Assembly
        }.ToImmutableList();

        public static Assembly[] GetAssemblies()
        {
            Assemblies.AddRange(ProductAssemblies);
            return Assemblies.ToArray();
        }
    }
}
