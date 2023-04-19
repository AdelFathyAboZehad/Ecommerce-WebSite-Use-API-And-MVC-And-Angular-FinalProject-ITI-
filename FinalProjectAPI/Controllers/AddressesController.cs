using Application.Features.Addesses.Commands.CreateAddress;
using Application.Features.Addesses.Commands.DeleteAddress;
using Application.Features.Addesses.Commands.UpdateAddress;
using Application.Features.Addesses.Queries.GetAddressDetails;
using Application.Features.Addesses.Queries.GetAllAddress;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost ("SetAdress")]
        public async Task<IActionResult> CreateAddress([FromBody] CreateAddressCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAddressForUSer([FromBody] GetAllAddressQuery query)
        {
            return Ok(await _mediator.Send(query));

        }

        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetailsAddress([FromBody] GetAddressDetailsQuery query)
        {
            return Ok(await _mediator.Send(query));

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAddress([FromBody] DeleteAddressCommand command)
        {
            return Ok(await _mediator.Send(command));

        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAddress([FromBody] UpdateAddressCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
