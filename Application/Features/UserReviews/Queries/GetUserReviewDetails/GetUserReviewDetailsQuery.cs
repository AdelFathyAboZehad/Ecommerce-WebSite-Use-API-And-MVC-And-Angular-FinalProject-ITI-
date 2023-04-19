using Dtos.Product;
using Dtos.UserReview;
using Dtos.Users;
using MediatR;

namespace Application.Features.UserReviews.Queries.GetUserReviewDetails
{
    public class GetUserReviewDetailsQuery : IRequest<UserReviewMinimalDto>
    {
        public int Id { get; set; }
      
    }
}
