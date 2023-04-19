using Application.Features.Orders.Commands.CreateOrder;
using Application.Features.Orders.Commands.DeleteOrder;
using Application.Features.Orders.Queries.GetAllOrders;
using Application.Features.Orders.Queries.GetOrderDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet ("GetOrders")]
        public async Task<IActionResult> GetAllOrder([FromQuery] GetAllOrdersQuery query)
        {
            return Ok(await _mediator.Send(query));
        }


        [HttpPost("createOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder([FromBody] DeleteOrderCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetailsOrder([FromQuery] GetOrderDetailsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
