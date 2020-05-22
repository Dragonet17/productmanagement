using MediatR;
using ProductManagement.Database.Database;
using ProductManagement.Infrastructure.Commands;
using ProductManagement.Infrastructure.Dtos;
using ProductManagement.Infrastructure.Mappers;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.Infrastructure.Handlers.Product
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly ProductManagementContext _context;
        private readonly IProductMapper _productMapper;

        public CreateProductHandler(ProductManagementContext context,
            IProductMapper productMapper)
        {
            _context = context;
            _productMapper = productMapper;
        }
        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken = default)
        {
            var product = new Database.Entities.Product(request.Name, request.Number, request.Quantity, 0);
            await _context.AddAsync(product, cancellationToken);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result == 1 ? _productMapper.Map(product) : null;
        }
    }
}
