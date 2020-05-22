using System;
using System.Linq;
using System.Threading.Tasks;
using ProductManagement.Infrastructure.Handlers;
using ProductManagement.Infrastructure.Handlers.Product.Queries;
using ProductManagement.Infrastructure.Mappers;
using ProductManagement.Infrastructure.Queries;
using ProductManagement.UnitTests.DbContext;
using Shouldly;
using Xunit;

namespace ProductManagement.UnitTests.Handlers.Product
{
    public class GetProductByIdHandlerTest
    {
        [Fact]
        public async Task GetProductById()
        {
            var query = new GetProductByIdQuery(Guid.NewGuid());
            var contextProvider = new ProductContextTestProvider();
            using var context = contextProvider.GetContext();
            var handler = new GetProductByIdHandler(context, new ProductMapper());
            contextProvider.AddProduct(new Database.Entities.Product(query.Id, "Name1", "Number1", 11, 22));
            contextProvider.AddProduct(new Database.Entities.Product(Guid.NewGuid(), "Name2", "Number2", 12, 23));
            contextProvider.AddProduct(new Database.Entities.Product(Guid.NewGuid(), "Name3", "Number3", 13, 24));
            var productCount = context.Products.Count();

            var result = await handler.Handle(query);

            productCount.ShouldBe(3);
            result.ShouldNotBeNull();
            result.Number.ShouldBe("Number1");
            result.Name.ShouldBe("Name1");
            result.Quantity.ShouldBe(11);
        }

        [Fact]
        public async Task GetProductWhichIsNotInDb()
        {
            var query = new GetProductByIdQuery(Guid.NewGuid());
            using var context = new ProductContextTestProvider().GetContext();
            var handler = new GetProductByIdHandler(context, new ProductMapper());
            var productCount = context.Products.Count();

            var result = await handler.Handle(query);

            productCount.ShouldBe(0);
            result.ShouldBeNull();
        }
    }
}
