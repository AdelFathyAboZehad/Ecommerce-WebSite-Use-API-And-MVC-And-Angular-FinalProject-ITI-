
using Application.Features.Products.Queries.GetAllProducts;
using Application.Features.Products.Queries.GetProductDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="Admin,User")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("AllProduct")]

        public async Task<IActionResult> GetAllProducts([FromQuery] FilterProductsQuery com)
        {
            return Ok(await _mediator.Send(com));
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetAllProductDetails(long? id)
        {
            if (id == null)
                return NotFound($"No ID with this {id}");
            return Ok(await _mediator.Send(new GetProductDetailsQuery(id.Value)));
        }





    }
}
