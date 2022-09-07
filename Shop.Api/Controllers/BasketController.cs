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

namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("api/Basket")]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Basket>> GetBasket([FromRoute] int id)
        {
            var basket = await _mediator.Send(new GetDetailBasketQuery { Id = id });
            return Ok(basket);
        }
        [HttpPost]
        public async Task<ActionResult<int>> CreateBasket([FromBody] CreateBasketCommand command)
        {
            var basketId = await _mediator.Send(command);
            return Ok(basketId);
        }
        [HttpPatch]
        public async Task<ActionResult<double>> AddProductsToBasket([FromBody] AddProductToBasketCommand command)
        {
            var price = await _mediator.Send(command);
            return Ok(price);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductFromBasket([FromBody] DeleteProductFromBasketCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }




    }
}
