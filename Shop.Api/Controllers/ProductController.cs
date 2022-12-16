using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Functions.Products.Commands.CreateProduct;
using Shop.Application.Functions.Products.Commands.DeleteProduct;
using Shop.Application.Functions.Products.Commands.UpdateProduct;
using Shop.Application.Functions.Products.GetProductDetail;
using Shop.Application.Functions.Products.GetProductsList;
using Shop.Application.Functions.Users.Queries.GetUserDetail;
using Shop.Persistence.EF.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Route("api/Product")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet(Name = "GetAllproducts")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProducts([FromQuery] ProductQuery productQuery)
        {
            var products = await _mediator.Send(new GetProductsListQuery { ProductQuery = productQuery});
            return Ok(products);
        }
        [HttpGet("{id}", Name = "GetProduct")]
        [AllowAnonymous]

        public async Task<IActionResult> GetProduct(int id)
        {
            var Product = await _mediator.Send(new GetProductDetailQuery() { Id = id });
            return Ok(Product);
        }
        [HttpPost(Name = "CreateProduct")]
        
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand createProductCommand)
        {
            var ProductId = await _mediator.Send(createProductCommand);
            return Ok(ProductId);
        }
        [HttpDelete("{id}", Name = "DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var command = new DeleteProductCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpPatch(Name = "UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand updateProductCommand)
        {
            await _mediator.Send(updateProductCommand);
            return NoContent();
        }
    }
}
