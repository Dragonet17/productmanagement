using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Database.Database;
using ProductManagement.Infrastructure.Commands;
using ProductManagement.Infrastructure.Dtos;
using ProductManagement.Infrastructure.Mappers;

namespace ProductManagement.Infrastructure.Handlers.Product
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        private readonly ProductManagementContext _context;
        private readonly IProductMapper _productMapper;

        public UpdateProductHandler(ProductManagementContext context,
            IProductMapper productMapper)
        {
            _context = context;
            _productMapper = productMapper;
        }
        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken = default)
        {
            var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (product == null)
                return null;
            _context.Update(product.Update(request.Name, request.Number, request.Quantity, request.Price));
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result == 1 ? _productMapper.Map(product) : null;
        }
    }
}
