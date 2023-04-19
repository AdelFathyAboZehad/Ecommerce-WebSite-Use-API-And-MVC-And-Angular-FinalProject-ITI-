

using Domian;

namespace Application.Contracts.Orders
{
    public interface IOrderRepository : IRepository<Order, int>
    {
        Task<IEnumerable<Order>> GetAllOrdersForAUserAsync(int userId);
        Task<Domian.User?> GetAllOrderWithDetails(int userid);
      
    }
}
