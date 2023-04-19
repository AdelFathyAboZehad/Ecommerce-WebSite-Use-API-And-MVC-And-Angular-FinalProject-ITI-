using AdminSiteUseMVC.Models.Services.UserReviews;
using AdminSiteUseMVC.ViewModel.UserReviews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminSiteUseMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserReviewsController : Controller
    {
        private readonly UserReviewRepository _userReviewRepository;

        public UserReviewsController(UserReviewRepository userReviewRepository)
        {
            _userReviewRepository = userReviewRepository;
        }
        public async Task<IActionResult> Index()
        {
            var userReviews =  _userReviewRepository.GetAllDetailsAsync();
            if(userReviews!=null)
            {
                List<UserReviewViewModel> users = new List<UserReviewViewModel>();
                foreach (var item in userReviews)
                {
                    users.Add(new UserReviewViewModel
                    {
                        Id = item.Id,
                        RatingValue = item.RatingValue,

                        Comment= item.Comment,
                        Date = item.Date,
                        ProductName = item.Product.NameEN,
                        UserName = item.User.Fname + " " + item.User.Lname
                    });
                }
                return View(users);
            }
            else
            { return View(); }
          
        }
    }
}
