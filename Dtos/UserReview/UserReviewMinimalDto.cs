using System.ComponentModel.DataAnnotations;

namespace Dtos.UserReview
{
    public class UserReviewMinimalDto
    {
        public int Id { get; set; }
        [Range(0, 5)]
        public int? RatingValue { get; set; }
        [MaxLength(200), MinLength(7)]
        public string? Comment { get; set; }
        public DateTime? Date { get; set; }
    }
}
