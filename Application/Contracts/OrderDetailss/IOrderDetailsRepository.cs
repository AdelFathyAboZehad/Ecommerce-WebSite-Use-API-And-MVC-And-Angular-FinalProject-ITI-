using Domian;

namespace Application.Contracts.OrderDetailss
{
    public interface IOrderDetailsRepository:IRepository<OrderDetails,int>
    {
        //Task<IEnumerable<OrderDetails>> FilterByAsync(string? filter = null);
    }
}
