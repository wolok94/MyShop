using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Functions.Order.Queries.GetOrdersInList;
using Shop.Application.Functions.Orders.Command.CreateOrder;
using Shop.Application.Functions.Orders.Command.DeleteOrder;
using Shop.Application.Functions.Orders.Queries.GetOrderDetail;
using Shop.Application.Functions.Orders.UpdateOrder;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("api/Order")]
    [Authorize(Roles = "Admin")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task <IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var order = await _mediator.Send(command, CancellationToken.None);
            return Ok(order);
        }
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _mediator.Send(new GetOrdersInListViewQuery(), CancellationToken.None);
            return Ok(orders);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task <IActionResult> GetOrder([FromRoute] int id)
        {
            var order = await _mediator.Send(new GetOrderDetailQuery { Id = id });
            return Ok(order);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task <IActionResult> DeleteOrder([FromRoute] int id)
        {
            await _mediator.Send(new DeleteOrderCommand { Id = id });
            return NoContent();
        }
        [HttpPut]
        public async Task <IActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
