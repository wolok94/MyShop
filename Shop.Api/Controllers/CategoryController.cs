using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Functions.Categories.Commands.CreateCategory;
using Shop.Application.Functions.Categories.Commands.DeleteCategory;
using Shop.Application.Functions.Categories.Commands.UpdateCategory;
using Shop.Application.Functions.Categories.Queries.GetCategoriesList;
using Shop.Application.Functions.Categories.Queries.GetCategoryDetail;
using Shop.Application.Functions.Users.Queries.GetUserDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet(Name = "GetAllCategories")]
        public async Task<ActionResult<List<CustomerViewModel>>> GetCategories()
        {
            var categories = await _mediator.Send(new GetCategoryInListQuery());
            return Ok(categories);
        }
        [HttpGet("{id}",Name = "GetCategory")]

        public async Task<ActionResult<CustomerViewModel>> GetCategory(int id)
        {
            var category = await _mediator.Send(new GetCategoryDetailsQuery() { Id = id });
            return Ok(category);
        }
        [HttpPost(Name = "CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var categoryId = await _mediator.Send(createCategoryCommand);
            return Ok(categoryId);
        }
        [HttpDelete("{id}",Name = "DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var command = new DeleteCategoryCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpPatch(Name = "UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            await _mediator.Send(updateCategoryCommand);
            return NoContent();
        }
    }

}
