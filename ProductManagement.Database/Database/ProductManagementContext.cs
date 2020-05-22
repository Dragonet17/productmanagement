using ApplicationIdentity.Database.Context;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Database.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.Database.Database
{
    public class ProductManagementContext : ApplicationDbContext<ProductManagementContext>
    {
        public ProductManagementContext(DbContextOptions<ProductManagementContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.BuildEntities();

        }

        public override Task<int> SaveChangesAsync(CancellationToken token = default(CancellationToken)) =>
            base.SaveChangesAsync(true, token);

        public DbSet<Product> Products { get; set; }
    }
}
