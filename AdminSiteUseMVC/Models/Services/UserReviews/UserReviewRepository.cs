using AdminSiteUseMVC.Models.Services.GeneralRepositories;
using DbContextL;
using Domian;
using Microsoft.EntityFrameworkCore;

namespace AdminSiteUseMVC.Models.Services.UserReviews
{
    public class UserReviewRepository : GeneralRepository<UserReview, int>
    {
        public UserReviewRepository(Context context) : base(context)
        {
        }
        public async Task<UserReview?> GetByIdAllDetailsAsync(int id)
        {
            return await (
                _context.UserReviews
                .Include(p => p.User)
                .Include(p => p.Product)
                .FirstAsync(p => p.Id == id));
        }
        public  IEnumerable<UserReview> GetAllDetailsAsync()
        {
            return _context.UserReviews
                    .Include(p => p.User)
                    .Include(p => p.Product);
        }
    }
}
