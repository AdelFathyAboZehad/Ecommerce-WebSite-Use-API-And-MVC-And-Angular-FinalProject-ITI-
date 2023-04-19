using Application.Features.OrderDetailss.Commands.CreateOrderDetails;
using Application.Features.UserReviews.Command.CreateReview;
using Application.Features.UserReviews.Queries.FilterUserReviews;
using Application.Features.UserReviews.Queries.GetUserReviewDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPI.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly IMediator _mediator;

        public OrderDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetails([FromBody] CreateOrderDetailsCommand query)
        {
            return Ok(await _mediator.Send(query));
        }

      
    }
}
