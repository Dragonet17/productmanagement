using System;
using MediatR;
using ProductManagement.Infrastructure.Dtos;

namespace ProductManagement.Infrastructure.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public readonly Guid Id;

        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
