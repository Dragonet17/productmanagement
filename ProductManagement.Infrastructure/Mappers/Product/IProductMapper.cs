using System.Collections.Generic;
using ProductManagement.Database.Entities;
using ProductManagement.Infrastructure.Dtos;

namespace ProductManagement.Infrastructure.Mappers
{
    public interface IProductMapper
    {
        ProductDto Map(Product product);
        List<ProductDto> Map(List<Product> products);
    }
}
