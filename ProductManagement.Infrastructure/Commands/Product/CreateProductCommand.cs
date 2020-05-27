using System.ComponentModel.DataAnnotations;
using MediatR;
using ProductManagement.Infrastructure.Dtos;

namespace ProductManagement.Infrastructure.Commands
{
    public class CreateProductCommand : IRequest<ProductDto>
    {
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
    }
}
