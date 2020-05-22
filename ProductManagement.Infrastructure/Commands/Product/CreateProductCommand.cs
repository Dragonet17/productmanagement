using MediatR;
using ProductManagement.Infrastructure.Dtos;

namespace ProductManagement.Infrastructure.Commands
{
    public class CreateProductCommand : IRequest<ProductDto>
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
