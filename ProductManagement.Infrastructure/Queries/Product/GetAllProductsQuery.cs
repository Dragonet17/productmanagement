using MediatR;
using ProductManagement.Infrastructure.Dtos;
using System.Collections.Generic;

namespace ProductManagement.Infrastructure.Queries
{
    public class GetAllProductsQuery: IRequest<List<ProductDto>>
    {
    }
}
