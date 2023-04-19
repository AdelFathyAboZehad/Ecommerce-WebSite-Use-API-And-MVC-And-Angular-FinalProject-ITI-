using Application.Contracts;
using Dtos.UserReview;
using MediatR;

namespace Application.Features.UserReviews.Queries.FilterUserReviews
{
    public class FilterUserReviewsQueryHandler : IRequestHandler<FilterUserReviewsQuery, IEnumerable<UserReviewLargeDto>>
    {
        private readonly IUserReviewRepository _userReviewRepository;

        public FilterUserReviewsQueryHandler(IUserReviewRepository userReviewRepository)
        {
            _userReviewRepository = userReviewRepository;
        }
        public async Task<IEnumerable<UserReviewLargeDto>> Handle(FilterUserReviewsQuery request, CancellationToken cancellationToken)
        {
            var results = await _userReviewRepository.FilterByAsync(request.RatingValue, request.Date);
            if (results != null)
            {
                return (results).Select(x => new UserReviewLargeDto
                {
                    Comment = x.Comment,
                    RatingValue = x.RatingValue,
                    Date = x.Date,
                    ProductName = x.Product.NameEN,
                    UserName = "adel"

                }); 

            }
            else
                throw new Exception("No Reviews");
        }
    }
}
