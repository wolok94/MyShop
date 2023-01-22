using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Functions.ProductCarts.Queries.GetProductIdsByShoppingCartIds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("api/ProductCart")]
    [Authorize(Roles ="Admin, User")]
    public class ProductCartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductCartController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductIdsByShoppingCartId([FromRoute] int id)
        {
            var productIds = await _mediator.Send(new GetProductIdsByShoppintCartIdsQuery { ShoppingCartId = id }, CancellationToken.None);
            return Ok(productIds);
        }
    }
}
