using Application.Features.UserReviews.Command.CreateReview;
using Application.Features.UserReviews.Queries.FilterUserReviews;
using Application.Features.UserReviews.Queries.GetUserReviewDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserReviewController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] CreateUserReviewCommand query) {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("allreview")]

        public async Task<IActionResult> GetAllUserReviews([FromBody] FilterUserReviewsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetUserReviewDetails(int? id)
        {
            if (id == null)
                return NotFound($"No ID with this {id}");
            try
            {
                return Ok(await _mediator.Send(new GetUserReviewDetailsQuery() { Id = id.Value }));

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

    }
}
