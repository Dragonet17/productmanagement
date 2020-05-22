using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Database.Database;
using ProductManagement.Infrastructure.Commands;
using ProductManagement.Infrastructure.Mappers;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.Infrastructure.Handlers.Product
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly ProductManagementContext _context;
        private readonly IProductMapper _productMapper;

        public DeleteProductHandler(ProductManagementContext context,
            IProductMapper productMapper)
        {
            _context = context;
            _productMapper = productMapper;
        }

        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken = default)
        {
            var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (product == null)
                return 0;
            _context.Remove(product);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
