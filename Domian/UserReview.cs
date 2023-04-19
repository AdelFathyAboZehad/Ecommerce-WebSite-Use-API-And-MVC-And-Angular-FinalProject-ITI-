using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domian
{
    [Table("UserReview")]
    public class UserReview
    {
        public int Id { get; set; }
        [Range(0, 5)]
        public int? RatingValue { get; set; }
        [MaxLength(200), MinLength(7)]
        public string Comment{ get; set; }
        public DateTime Date { get; set; }

        //relation with user

        public virtual User? User { get; set; }

        //relation with Product

        public virtual Product Product { get; set; }

        public UserReview(DateTime date, User user, Product product, string comment, int? ratingValue = null)
        {
            RatingValue = ratingValue;
            Comment = comment;
            Date = date;
            User = user;
            Product = product;
        }
        public UserReview() : this(DateTime.Now, null!, null!, null!)
        {

        }
    }
}
