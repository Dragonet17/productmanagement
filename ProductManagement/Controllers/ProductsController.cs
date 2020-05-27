using ApplicationIdentity.Controllers;
using ApplicationIdentity.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Infrastructure.Commands;
using ProductManagement.Infrastructure.Queries;
using ProductManagement.Models;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ProductManagement.Infrastructure.Consts;

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());
            return View(result);
        }

        public IActionResult Create() => View(new CreateProductCommand());

        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return result == null ? RedirectToAction("Error", new Error(Operation.Name.Add)) : RedirectToAction("Index");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var query = new GetProductByIdQuery(id);
            var result = await _mediator.Send(query);
            return View(new UpdateProductCommand(result));
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return result == null ? RedirectToAction("Error", new Error(Operation.Name.Edit)) : RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var query = new GetProductByIdQuery(id);
            var result = await _mediator.Send(query);
            return View(new UpdateProductCommand(result));
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProduct(UpdateProductCommand command)
        {
            var deleteCommand = new DeleteProductCommand(command);
            var result = await _mediator.Send(deleteCommand);
            return result == 0 ? RedirectToAction("Error", new Error(Operation.Name.Delete)) : RedirectToAction("Index");
        }

        public IActionResult Error(Error error)
        {
            return View(error);
        }
    }
}
