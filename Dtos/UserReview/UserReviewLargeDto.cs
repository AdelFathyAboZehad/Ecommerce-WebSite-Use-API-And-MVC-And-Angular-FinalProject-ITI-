using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.UserReview
{
    public class UserReviewLargeDto
    {
      
        [Range(0, 5)]
        public int? RatingValue { get; set; }
        [MaxLength(200), MinLength(7)]
        public string? Comment { get; set; }
        public DateTime? Date { get; set; }
        public string UserName { get; set; }
        public string ProductName { get; set; }
    }
}
