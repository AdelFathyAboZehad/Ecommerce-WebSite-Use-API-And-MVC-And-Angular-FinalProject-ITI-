using Dtos.UserReview;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.UserReviews.Queries.FilterUserReviews
{
    public class FilterUserReviewsQuery:IRequest<IEnumerable<UserReviewLargeDto>>
    {
        public int? RatingValue { get; set; }
        public DateTime? Date { get; set; }

        
    }
}
