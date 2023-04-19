using Application.Features.Brands.Queries.FilterBrands;
using Application.Features.Brands.Queries.GetBrandDetails;
using Application.Features.Products.Queries.GetAllProducts;
using Application.Features.Products.Queries.GetProductDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("AllBrands")]

        public async Task<IActionResult> GetAllBrands([FromQuery] FilterBrandQuery com)
        {
            return Ok(await _mediator.Send(com));
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetAllBrandDetails(int? id)
        {
            if (id == null)
                return NotFound($"No ID with this {id}");
            return Ok(await _mediator.Send(new GetBrandDetailsQuery(id.Value)));
        }
    }
}
