using System;
using MediatR;

namespace ProductManagement.Infrastructure.Commands
{
    public class DeleteProductCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}
