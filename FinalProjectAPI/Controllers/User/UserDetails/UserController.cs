using Application.Features.Users.Commands.UpdateUserProfiles;
using Application.Features.Users.Commands.UpdateUsersPassword;
using Application.Features.Users.Queries.GetUserDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPI.Controllers//.User.UserDetails
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPatch("UpdateInfo")]
        public async Task<IActionResult> UpdateUserProfile([FromBody] UpdateUserprofileCommandQuery query)
        {


            return Ok(await _mediator.Send(query));
        }
        [HttpGet]
        public async Task<IActionResult> getuserdetails([FromQuery] UserDetailsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }



    }
}
