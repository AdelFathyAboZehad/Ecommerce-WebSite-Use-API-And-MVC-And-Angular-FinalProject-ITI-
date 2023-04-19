using Application.Contracts;
using DbContextL;
using Domian;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure
{
    public class UserReviewRepository : Repository<UserReview, int>, IUserReviewRepository
    {
        public UserReviewRepository(Context context) : base(context)
        {

        }

        public  async Task<IEnumerable<UserReview>> FilterByAsync(int? filterRating = null, DateTime? dateTime = null)
        {
            var result= _context.UserReviews.Include(a=>a.Product).Include(a=>a.User)
                .Where(x=> filterRating ==null? true: x.RatingValue==filterRating)
                .Where(x=> dateTime == null? true : x.Date == dateTime).ToList();
            return  result;
        }
    }

}
