using ProductManagement.Infrastructure.Commands;
using ProductManagement.Infrastructure.Handlers.Product;
using ProductManagement.Infrastructure.Mappers;
using ProductManagement.UnitTests.DbContext;
using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ProductManagement.UnitTests.Handlers.Product
{
    public class CreateProductHandlerTest
    {
        [Fact]
        public async Task CreateProductTest()
        {
            var request = new CreateProductCommand()
            {
                Number = "Number",
                Name = "Name",
                Quantity = 17
            };

            using var context = new ProductContextTestProvider().GetContext();
            var handler = new CreateProductHandler(context, new ProductMapper());
            var productCount = context.Products.Count();

            var result = await handler.Handle(request);

            var productCountAfterOperation = context.Products.Count();
            result.ShouldNotBeNull();
            result.Number.ShouldBe("Number");
            result.Name.ShouldBe("Name");
            result.Quantity.ShouldBe(17);
            productCount.ShouldBe(0);
            productCountAfterOperation.ShouldBe(1);
        }
    }
}
