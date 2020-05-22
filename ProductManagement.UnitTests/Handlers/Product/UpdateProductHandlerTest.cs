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
    public class UpdateProductHandlerTest
    {
        private readonly UpdateProductCommand _request = new UpdateProductCommand()
        {
            Id = Guid.NewGuid(),
            Number = "Number",
            Name = "Name",
            Quantity = 17
        };

        [Fact]
        public async Task UpdateProduct()
        {
            var contextProvider = new ProductContextTestProvider();
            using var context = contextProvider.GetContext();
            contextProvider.AddProduct(new Database.Entities.Product(_request.Id, "Name1","Number1",11,22));
            var handler = new UpdateProductHandler(context, new ProductMapper());
            var productCount = context.Products.Count();

            var result = await handler.Handle(_request);

            var productCountAfterOperation = context.Products.Count();
            productCount.ShouldBe(1);
            productCountAfterOperation.ShouldBe(1);
            result.ShouldNotBeNull();
            result.Number.ShouldBe("Number");
            result.Name.ShouldBe("Name");
            result.Quantity.ShouldBe(17);
        }

        [Fact]
        public async Task UpdateProductWhenDbIsEmpty()
        {
            using var context = new ProductContextTestProvider().GetContext();
            var handler = new UpdateProductHandler(context, new ProductMapper());
            var productCount = context.Products.Count();

            var result = await handler.Handle(_request);

            var productCountAfterOperation = context.Products.Count();
            productCount.ShouldBe(0);
            productCountAfterOperation.ShouldBe(0);
            result.ShouldBeNull();
        }

        [Fact]
        public async Task UpdateProductWhichIsNotInDb()
        {
            var id = Guid.NewGuid();
            var contextProvider = new ProductContextTestProvider();
            using var context = contextProvider.GetContext();
            contextProvider.AddProduct(new Database.Entities.Product(id, "Name1", "Number1", 11, 22));
            var handler = new UpdateProductHandler(context, new ProductMapper());
            var productCount = context.Products.Count();

            var result = await handler.Handle(_request);

            var productCountAfterOperation = context.Products.Count();
            productCount.ShouldBe(1);
            productCountAfterOperation.ShouldBe(1);
            result.ShouldBeNull();
            var productDb = context.Products.SingleOrDefault(x => x.Id == id);
            productDb.ShouldNotBeNull();
            productDb.Number.ShouldBe("Number1");
            productDb.Name.ShouldBe("Name1");
            productDb.Quantity.ShouldBe(11);
        }
    }
}
