using System.Collections.Generic;
using System.Linq;
using ProductManagement.Database.Entities;
using ProductManagement.Infrastructure.Dtos;

namespace ProductManagement.Infrastructure.Mappers
{
    public class ProductMapper : IProductMapper
    {
        public ProductDto Map(Product product) =>
            product == null ? null : new ProductDto(product.Id, product.Number, product.Name, product.Quantity);

        public List<ProductDto> Map(List<Product> products) =>
             products == null ? new List<ProductDto>() : products.Select(Map).ToList();
    }
}
