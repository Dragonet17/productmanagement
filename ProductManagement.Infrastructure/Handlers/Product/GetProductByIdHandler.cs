using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Database.Database;
using ProductManagement.Infrastructure.Dtos;
using ProductManagement.Infrastructure.Mappers;
using ProductManagement.Infrastructure.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.Infrastructure.Handlers.Product
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly ProductManagementContext _context;
        private readonly IProductMapper _productMapper;

        public GetProductByIdHandler(ProductManagementContext context,
            IProductMapper productMapper)
        {
            _context = context;
            _productMapper = productMapper;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken = default) =>
            _productMapper.Map(await _context.Products.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken));
    }
}
