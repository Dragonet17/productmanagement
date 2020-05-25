using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Database.Database;
using ProductManagement.Infrastructure.Dtos;
using ProductManagement.Infrastructure.Mappers;
using ProductManagement.Infrastructure.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.Infrastructure.Handlers
{
    public class GetAllProductsHandler: IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly ProductManagementContext _context;
        private readonly IProductMapper _productMapper;

        public GetAllProductsHandler(ProductManagementContext context,
            IProductMapper productMapper)
        {
            _context = context;
            _productMapper = productMapper;
        }

        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken = default)
        {
            return _productMapper.Map(await _context.Products.ToListAsync(cancellationToken));
        }
    }
}
