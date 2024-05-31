using Application.Products.Commands.CreateNewProduct;
using Application.Products.Queries.GetProductsByTenant;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{slugTenant}/[controller]")]
        [Authorize]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _mediator.Send(new GetProductsByTenantQuery());
            return Ok(result);
        }

        [HttpPost("{slugTenant}/[controller]")]
        [Authorize]
        public async Task<IActionResult> CreateProduct(
            CreateNewProductCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
