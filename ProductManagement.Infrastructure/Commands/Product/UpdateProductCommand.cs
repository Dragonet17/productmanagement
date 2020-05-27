using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using ProductManagement.Infrastructure.Dtos;

namespace ProductManagement.Infrastructure.Commands
{
    public class UpdateProductCommand : IRequest<ProductDto>
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Number { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public UpdateProductCommand()
        {
        }

        public UpdateProductCommand(ProductDto productDto)
        {
            if (productDto == null) return;
            Id = productDto.Id;
            Number = productDto.Number;
            Name = productDto.Name;
            Quantity = productDto.Quantity;
        }
    }
}
