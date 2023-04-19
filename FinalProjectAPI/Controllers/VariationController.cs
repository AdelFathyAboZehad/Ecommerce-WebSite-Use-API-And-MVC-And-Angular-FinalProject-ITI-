using Application.Features.Brands.Queries.FilterBrands;
using Application.Features.Brands.Queries.GetBrandDetails;
using Application.Features.Variations.Queries.FilterVariations;
using Application.Features.Variations.Queries.GetVariationsDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VariationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllVariation([FromBody] FilterVariationsQuery com)
        {
            return Ok(await _mediator.Send(com));
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetAllVariationDetails(int? id)
        {
            if (id == null)
                return NotFound($"No ID with this {id}");
            return Ok(await _mediator.Send(new GetVariationsDetailsQuery(id.Value)));
        }
    }
}
