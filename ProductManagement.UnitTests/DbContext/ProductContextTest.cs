using Microsoft.EntityFrameworkCore;
using ProductManagement.Database.Database;
using ProductManagement.Database.Entities;
using System;

namespace ProductManagement.UnitTests.DbContext
{
    public class ProductContextTestProvider
    {
        private ProductManagementContext _context;
        public ProductManagementContext GetContext()
        {
            var options = new DbContextOptionsBuilder<ProductManagementContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;
            _context = new ProductManagementContext(options);
            return _context;
        }

        public void AddProduct(Product product)
        {
            _context ??= GetContext();
            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}
