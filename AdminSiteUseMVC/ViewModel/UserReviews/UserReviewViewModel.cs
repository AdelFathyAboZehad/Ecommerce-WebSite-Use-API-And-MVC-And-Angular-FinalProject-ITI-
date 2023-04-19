using System.ComponentModel.DataAnnotations;

namespace AdminSiteUseMVC.ViewModel.UserReviews
{
    public class UserReviewViewModel
    {
        public int Id { get; set; }
        [Range(0, 5)]
        [Display(Name = "Rate")]
        public int? RatingValue { get; set; }
      
        [MaxLength(200), MinLength(7)]
        [Display(Name = "Comment")]
        public string? Comment { get; set; }
        public DateTime Date { get; set; }
        [Display(Name = "User")]
        public string? UserName { get; set; }
        [Display(Name = "Product")]
        public string? ProductName { get; set; }


    }
}
