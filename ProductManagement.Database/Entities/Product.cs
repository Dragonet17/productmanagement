using System;
using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Database.Entities
{
    public class Product
    {
        [Required]
        public Guid Id { get; private set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; private set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Number { get; private set; }

        [Required]
        public int Quantity { get; private set; }

        public decimal Price { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }
        public string CreatedBy { get; private set; }

        public Product(string name, string number, int quantity, decimal price)
        {
            Name = name;
            Number = number;
            Quantity = quantity;
            Price = price;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Product(Guid id, string name, string number, int quantity, decimal price)
        {
            Id = id;
            Name = name;
            Number = number;
            Quantity = quantity;
            Price = price;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Product Update(string name, string number, int quantity, decimal price)
        {
            UpdatedAt = DateTime.UtcNow;
            Name = name;
            Number = number;
            Quantity = quantity;
            Price = price;
            return this;
        }
    }
}
