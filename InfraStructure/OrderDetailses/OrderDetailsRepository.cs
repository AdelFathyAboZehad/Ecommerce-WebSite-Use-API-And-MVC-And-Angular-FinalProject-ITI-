using Application.Contracts.OrderDetailss;
using DbContextL;
using Domian;

namespace InfraStructure.OrderDetailses
{
    public class OrderDetailsRepository : Repository<OrderDetails, int>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(Context context) : base(context)
        {
        }
    }
}
