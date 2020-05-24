using System;

namespace ProductManagement.Infrastructure.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; }
        public string Number { get; }
        public string Name { get; }
        public int Quantity { get; }

        public ProductDto(Guid id, string number, string name, int quantity)
        {
            Id = id;
            Number = number;
            Name = name;
            Quantity = quantity;
        }
    }
}
