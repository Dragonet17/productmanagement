using Microsoft.EntityFrameworkCore;
using ProductManagement.Database.Entities;

namespace ProductManagement.Database.Database.EntityModelBuilders
{
    public static class ProductModelBuilder
    {
        public static ModelBuilder BuildProduct(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(x => x.Id);
            return modelBuilder;
        }
    }
}
