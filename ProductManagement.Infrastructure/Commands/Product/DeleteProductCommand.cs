using System;
using MediatR;

namespace ProductManagement.Infrastructure.Commands
{
    public class DeleteProductCommand : IRequest<int>
    {
        public Guid Id { get; set; }

        public DeleteProductCommand()
        {
        }

        public DeleteProductCommand(UpdateProductCommand command)
        {
            if (command != null)
            {
                Id = command.Id;
            }
        }
    }
}
