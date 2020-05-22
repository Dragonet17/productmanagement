using Microsoft.EntityFrameworkCore;
using ProductManagement.Database.Database.EntityModelBuilders;

namespace ProductManagement.Database.Database
{
    public static class EntityModelBuilder
    {
        public static void BuildEntities(this ModelBuilder modelBuilder)
        {
            modelBuilder.BuildProduct();
        }
    }
}
