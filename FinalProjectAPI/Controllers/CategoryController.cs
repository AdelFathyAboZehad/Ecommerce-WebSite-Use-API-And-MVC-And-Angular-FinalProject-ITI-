
using Application.Features.Categories.Queries.GetAllCategories;
using Application.Features.Categories.Queries.GetCategoryDetails;

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator medaitor)
        {
            _mediator = medaitor;
        }

        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> FilterCategories([FromQuery] FilterCategoriesQuery query)
        {

            return Ok(await _mediator.Send(query));
        }
        [HttpGet("asd")]
        public async Task<IActionResult> GetCategoryDetails([FromQuery] GetCategoryDetailsQuery q)
        {
            return Ok(await _mediator.Send(q));
        }

        //[HttpPost("sd")]
        //public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        //{

        //    return Ok(await _mediator.Send(command));

        //}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCategory(DeleteCategoryCommand command)
        //{
        //    return Ok(await _mediator.Send(command));

        //}

        //[HttpPut("sd2")]
        //public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        //{
        //    return Ok(await _mediator.Send(command));
        //}
    }
}