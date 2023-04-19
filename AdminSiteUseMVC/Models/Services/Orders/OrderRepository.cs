using AdminSiteUseMVC.Models.Services.GeneralRepositories;
using DbContextL;
using Domian;
using Microsoft.EntityFrameworkCore;

namespace AdminSiteUseMVC.Models.Services.Orders
{
    public class OrderRepository : GeneralRepository<Order, int>
    {
        public OrderRepository(Context context) : base(context)
        {
        }
       public async Task<Order?> GetByIdAllDetailsAsync(int id)
        {
            return await _context.Orders
                    .Include(o=>o.OrderDetails)
                    .Include(o=>o.UserPaymetMethod.User)
                    .Include(o=>o.Address)
                    .FirstAsync(o=>o.Id==id);
        }
    }
}
