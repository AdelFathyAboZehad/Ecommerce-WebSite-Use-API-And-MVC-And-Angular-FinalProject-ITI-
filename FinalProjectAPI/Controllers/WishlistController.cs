using Application.Features.Wishlists.Command.Create;
using Application.Features.Wishlists.Command.Delete;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WishlistController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //[HttpPost]
        //public async Task<IActionResult> AddWishlist([FromHeader] int uid ,[FromBody] int pid)
        //{
        //    CreateWishlistCommand command = new CreateWishlistCommand() {uid=uid ,pid=pid  };
        //    return Ok(await _mediator.Send(command));
        //}
        [HttpPost]
        public async Task<IActionResult> AddWishlist([FromBody] CreateWishlistCommand command)
        {

            return Ok(await _mediator.Send(command));
        }
        [HttpDelete]
        public async Task<IActionResult> removeWishlist([FromBody] DeleteWishlistCommand c)
        {
            return Ok(await _mediator.Send(c));
        }
    }

}
