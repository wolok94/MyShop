using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Functions.Baskets.Command.CreateBasket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("api/Basket")]
    public class BasketControlles : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketControlles(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateBasket([FromBody] CreateBasketCommand command)
        {
            var basketId = await _mediator.Send(command);
            return Ok(basketId);
        }
    }
}
