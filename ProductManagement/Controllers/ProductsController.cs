using System;
using ApplicationIdentity.Controllers;
using ApplicationIdentity.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Infrastructure.Queries;
using System.Threading.Tasks;
using ProductManagement.Infrastructure.Commands;

namespace ProductManagement.Controllers
{
    public class ProductsController : ApplicationUserController
    {
        private readonly IMediator _mediator;
        public ProductsController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMediator mediator)
            : base(userManager, signInManager)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        public async Task<IActionResult> GetProduct(Guid id)
        {
            var query = new GetProductByIdQuery(id);
            var result = await _mediator.Send(query);
            return result == null ? (IActionResult)NotFound() : Ok(result);
        }

        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return result == null ? (IActionResult)NotFound() : Ok(result);
        }

        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return result == null ? (IActionResult)NotFound() : Ok(result);
        }

        public async Task<IActionResult> DeleteProduct(DeleteProductCommand command)
        {
            var result = await _mediator.Send(command);
            return result == 0 ? (IActionResult)NotFound() : Ok(result);
        }
    }
}
