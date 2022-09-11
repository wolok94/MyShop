using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Functions.Baskets.Command.AddProductsToBasket;
using Shop.Application.Functions.Baskets.Command.CreateBasket;
using Shop.Application.Functions.Baskets.Command.DeleteProductFromBasket;
using Shop.Application.Functions.Baskets.Query.GetDetailBasket;
using Shop.Application.Functions.Products.Commands.DeleteProduct;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("api/Basket")]
    [Authorize(Roles = "Admin, User")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShoppingCartController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBasket([FromRoute] int id)
        {
            var basket = await _mediator.Send(new GetDetailCartQuery { Id = id });
            return Ok(basket);
        }
        [HttpPost]

        public async Task<IActionResult> CreateShoppingCart([FromBody] CreateCartCommand command)
        {
            var shoppingCartId = await _mediator.Send(command);
            return Ok(shoppingCartId);
        }
        [HttpPatch]
        public async Task<IActionResult> AddProductsToBasket([FromBody] AddProductToCartCommand command)
        {
            var price = await _mediator.Send(command);
            return Ok(price);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductFromBasket([FromBody] DeleteProductFromCartCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }




    }
}
