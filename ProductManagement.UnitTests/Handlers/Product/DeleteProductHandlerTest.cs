using System;
using System.Linq;
using System.Threading.Tasks;
using ProductManagement.Infrastructure.Commands;
using ProductManagement.Infrastructure.Handlers.Product;
using ProductManagement.Infrastructure.Mappers;
using ProductManagement.UnitTests.DbContext;
using Shouldly;
using Xunit;

namespace ProductManagement.UnitTests.Handlers.Product
{
    public class DeleteProductHandlerTest
    {
        [Fact]
        public async Task DeleteProduct()
        {
            var request = new DeleteProductCommand() {Id = Guid.NewGuid()};
            var contextProvider = new ProductContextTestProvider();
            using var context = contextProvider.GetContext();
            contextProvider.AddProduct(new Database.Entities.Product(request.Id, "Name1", "Number1", 11, 22));
            var handler = new DeleteProductHandler(context, new ProductMapper());
            var productCount = context.Products.Count();

            var result = await handler.Handle(request);

            var productCountAfterOperation = context.Products.Count();
            productCount.ShouldBe(1);
            productCountAfterOperation.ShouldBe(0);
            result.ShouldNotBeNull();
            result.ShouldBe(1);
        }

        [Fact]
        public async Task DeleteProductWhenDbIsEmpty()
        {
            var request = new DeleteProductCommand() { Id = Guid.NewGuid() };
            using var context = new ProductContextTestProvider().GetContext();
            var handler = new DeleteProductHandler(context, new ProductMapper());
            var productCount = context.Products.Count();

            var result = await handler.Handle(request);

            var productCountAfterOperation = context.Products.Count();
            productCount.ShouldBe(0);
            productCountAfterOperation.ShouldBe(0);
            result.ShouldBe(0);
        }

        [Fact]
        public async Task DeleteProductWhichIsNotInDb()
        {
            var request = new DeleteProductCommand() { Id = Guid.NewGuid() };
            var contextProvider = new ProductContextTestProvider();
            using var context = contextProvider.GetContext();
            contextProvider.AddProduct(new Database.Entities.Product(Guid.NewGuid(), "Name1", "Number1", 11, 22));
            var handler = new DeleteProductHandler(context, new ProductMapper());
            var productCount = context.Products.Count();

            var result = await handler.Handle(request);

            var productCountAfterOperation = context.Products.Count();
            productCount.ShouldBe(1);
            productCountAfterOperation.ShouldBe(1);
            result.ShouldNotBeNull();
            result.ShouldBe(0);
        }
    }
}
