using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Functions.BasketProducts.Command.Create;
using Shop.Application.Functions.BasketProducts.Command.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("api/AddProductToCart")]
    public class BasketProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddProductToCart([FromBody] CreateBasketProductCommand command)
        {
            var basketProduct = await _mediator.Send(command);
            return Ok(basketProduct);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket([FromBody] DeleteBasketProductsCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
