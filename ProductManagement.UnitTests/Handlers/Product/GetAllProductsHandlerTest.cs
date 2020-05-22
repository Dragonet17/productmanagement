using ProductManagement.Infrastructure.Handlers;
using ProductManagement.Infrastructure.Mappers;
using ProductManagement.Infrastructure.Queries;
using ProductManagement.UnitTests.DbContext;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ProductManagement.UnitTests.Handlers.Product
{
    public  class GetAllProductsHandlerTest
    {
        [Fact]
        public async Task GetAll()
        {
            var query = new GetAllProductsQuery();
            var contextProvider = new ProductContextTestProvider();
            using var context = contextProvider.GetContext();
            var handler = new GetAllProductsHandler(context, new ProductMapper());
            contextProvider.AddProduct(new Database.Entities.Product(Guid.NewGuid(), "Name1", "Number1", 11, 22));
            contextProvider.AddProduct(new Database.Entities.Product(Guid.NewGuid(), "Name2", "Number2", 12, 23));
            contextProvider.AddProduct(new Database.Entities.Product(Guid.NewGuid(), "Name3", "Number3", 13, 24));
            var productCount = context.Products.Count();

            var result = await handler.Handle(query);

            productCount.ShouldBe(3);
            result.ShouldNotBeNull();
            result.ShouldNotBeEmpty();
            result.Count.ShouldBe(3);
        }

        [Fact]
        public async Task GetAllWhenDbIsEmpty()
        {
            var query = new GetAllProductsQuery();
            using var context = new ProductContextTestProvider().GetContext();
            var handler = new GetAllProductsHandler(context, new ProductMapper());
            var productCount = context.Products.Count();

            var result = await handler.Handle(query);

            productCount.ShouldBe(0);
            result.ShouldNotBeNull();
            result.ShouldBeEmpty();
        }
    }
}
