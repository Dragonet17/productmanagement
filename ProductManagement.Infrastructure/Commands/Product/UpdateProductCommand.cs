using System;
using MediatR;
using ProductManagement.Infrastructure.Dtos;

namespace ProductManagement.Infrastructure.Commands
{
    public class UpdateProductCommand : IRequest<ProductDto>
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
