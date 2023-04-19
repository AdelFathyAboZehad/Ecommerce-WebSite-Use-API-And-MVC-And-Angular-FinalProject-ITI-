using Application.Contracts;
using Dtos.UserReview;
using MediatR;

namespace Application.Features.UserReviews.Queries.GetUserReviewDetails
{
    public class GetUserReviewDetailsQueryHandler : IRequestHandler<GetUserReviewDetailsQuery, UserReviewMinimalDto>
    {
        private readonly IUserReviewRepository _userReviewRepository;

        public GetUserReviewDetailsQueryHandler(IUserReviewRepository userReviewRepository)
        {
            _userReviewRepository = userReviewRepository;
        }

        public async Task<UserReviewMinimalDto> Handle(GetUserReviewDetailsQuery request, CancellationToken cancellationToken)
        {
            var Review = await _userReviewRepository.GetDetailsAsync(request.Id);

            if (Review == null)
            {
                throw new Exception($"NO Review with This Id {request.Id}");
            }

            else
            {
                return new UserReviewMinimalDto() { Id = Review.Id, RatingValue = Review.RatingValue, Comment = Review.Comment, Date = Review.Date };
            }
        }
    }
}
