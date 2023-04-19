using Application.Features.Stocks.Queries.FilterStocks;
using Application.Features.Stocks.Queries.GetStockDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllStock([FromBody] FilterStockQuery com)
        {
            return Ok(await _mediator.Send(com));
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetAllStockDetails(int? id)
        {
            if (id == null)
                return NotFound($"No ID with this {id}");
            return Ok(await _mediator.Send(new GetStockDetailsQuery(id.Value)));
        }

    }
}
