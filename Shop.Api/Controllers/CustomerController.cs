using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Functions.Users.Commands.CreateUser;
using Shop.Application.Functions.Users.Commands.DeleteUser;
using Shop.Application.Functions.Users.Commands.UpdateUser;
using Shop.Application.Functions.Users.Queries.GetUserDetail;
using Shop.Application.Functions.Users.Queries.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]

        public async Task<ActionResult<CustomerViewModel>> Login([FromBody] LoginDto customerDto)
        {
            var customer = await _mediator.Send(new LoginCustomerQuery() { NickName = customerDto.NickName, Password = customerDto.Password });
            return Ok(customer);
        }

        [HttpGet("{id}", Name = "GetCustomer")]

        public async Task<ActionResult<CustomerViewModel>> GetCustomer(int id)
        {
            var customer = await _mediator.Send(new GetCustomerDetailQuery() { Id = id });
            return Ok(customer);
        }
        [HttpPost(Name = "CreateCustomer")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            var customerId = await _mediator.Send(createCustomerCommand);
            return Ok(customerId);
        }
        [HttpDelete("{id}", Name = "DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var command = new DeleteCustomerCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpPatch(Name = "UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            await _mediator.Send(updateCustomerCommand);
            return NoContent();
        }
    }
}
