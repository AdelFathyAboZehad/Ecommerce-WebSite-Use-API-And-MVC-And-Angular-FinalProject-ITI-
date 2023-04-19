using Domian;
using Dtos.UserReview;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserReviews.Command.CreateReview
{
    public class CreateUserReviewCommand :IRequest<UserReviewLargeDto>
    {
      
        [Range(0, 5)]
        public int? RatingValue { get; set; }
        [MaxLength(200), MinLength(7)]
        public string Comment { get; set; }
       

 

       // public  int UserId { get; set; }

        

        public  int ProductId { get; set; }
    }
}
